    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        // Make the "list" disabled, so the user can't "select an item" and cause an error, etc
        DisableUI();
        try
        {    
           // Run your operation asynchronously
           await ViewModel.CreateMessageCommand();
        }
        finally
        {
           EnableUI(); // Re-enable everything after the above completes
        }
    }
