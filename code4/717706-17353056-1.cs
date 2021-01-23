    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        radBusyIndicator.IsBusy = true;
        LoginButton.IsEnabled = false; // Prevent clicking twice
        long userId = 0;
        // Call async method with await, etc...
        string error = await DoLoginAsync(userId);
        var result = await BunchOfOtherCodeAsync();
        radBusyIndicator.IsBusy = false;
        LoginButton.IsEnabled = true;
     }
