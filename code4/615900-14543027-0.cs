    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var client = new FacebookClient();
        MessageBox.Show(client.GetLoginUrl(new object[0]).ToString());
    }
