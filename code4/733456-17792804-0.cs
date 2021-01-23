    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DisableUI(); // Make the "list" disabled, so the user can't "select and item" and cause an error, etc
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
