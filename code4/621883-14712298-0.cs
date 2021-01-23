    private async void btnLiveSignin_Click(object sender, RoutedEventArgs e)
    {
        busy.Visibility = System.Windows.Visibility.Visible;  // Display the please wait message
        if(await Login())
        {
           // Do something 
        }
    }
