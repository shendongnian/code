    private async void btnAsync01_Click(object sender, RoutedEventArgs e)
    {
        UpdateTxtLog("click button: " + System.DateTime.Now);
        await method01Async();
        UpdateTxtLog("after method01Async: " + System.DateTime.Now);
    }
