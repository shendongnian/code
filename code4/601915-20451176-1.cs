        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Press ok to show new dialog");
            UICommand okCommand = new UICommand("OK");
            UICommand cancelCommand = new UICommand("Cancel");
            dialog.Commands.Add(okCommand);
            dialog.Commands.Add(cancelCommand);
            IUICommand response = await dialog.ShowAsync();
            if( response == okCommand )
            {
                MessageDialog secondDialog = new MessageDialog("This is the second dialog");
                secondDialog.Commands.Add(new UICommand("OK"));
                await secondDialog.ShowAsync();
            }
        }
