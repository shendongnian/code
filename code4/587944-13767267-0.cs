    private async void LogOn_Click(object sender, RoutedEventArgs e)
    {
      btnLogon.IsEnabled = false;
      // Create database service for DI
      DataService _dataService = new DataService("MyData.sqlite");
      var uss = UserStartupService.GetInstance(_dataService);
      // progress bar...
      CurrentProgress.Visibility = Windows.UI.Xaml.Visibility.Visible;
      // create op and call...
      var op = uss.SetUpUser(txtUserId.Text)
          .AsTask(progress => { CurrentProgress.Value = progress; });
      var result = await op;
      txtMessage.Text = "Current user data already loaded...";
      CurrentProgress.Value = 100;
      btnLogon.IsEnabled = true;
    }
