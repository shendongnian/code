    private async void btnLiveSignin_Click(object sender, RoutedEventArgs e)
    {
        var loginTask = this.Login();
        busy.Visibility = System.Windows.Visibility.Visible; 
        await loginTask;
        if(loginTask.Result)
        {
           // Do something 
        }
    }
