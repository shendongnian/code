    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        btnStatus.Content = "Test started";
        await Task.Delay(3000); // Wait 3 seconds
        btnStatus.Content = "Test Ended"
    } 
