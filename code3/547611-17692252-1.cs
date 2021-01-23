    private void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            DoLogin();
        }
    }
    
    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        DoLogin();
    }
    
    private void DoLogin()
    {
        tbStatus.Text = "Login Done";
    }
