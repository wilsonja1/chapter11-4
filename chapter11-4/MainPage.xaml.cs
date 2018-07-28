﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace chapter11_4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool textChanged = false;
        bool loading = false;
        IStorageFile saveFile = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                MessageDialog overwriteDialog = new MessageDialog(
                   "You have unsaved changes. Are you sure you want to load a new file?");
                overwriteDialog.Commands.Add(new UICommand("Yes"));
                overwriteDialog.Commands.Add(new UICommand("No"));
                overwriteDialog.DefaultCommandIndex = 1;
                UICommand result = await overwriteDialog.ShowAsync() as UICommand;
                if (result != null && result.Label == "No")
                    return;
            }
            OpenFile();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
