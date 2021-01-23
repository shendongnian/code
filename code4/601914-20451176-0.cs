        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Press ok to show new dialog (the application will crash).");
            dialog.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(OnDialogOkTest1)));
            dialog.Commands.Add(new UICommand("Cancel"));
        
            await dialog.ShowAsync();
        }
        
        private async void OnDialogOkTest1(IUICommand command)
        {
            MessageDialog secondDialog = new MessageDialog("This is the second dialog");
            secondDialog.Commands.Add(new UICommand("OK"));
            await secondDialog.ShowAsync();
        }
