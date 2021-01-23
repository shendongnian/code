    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (e.NavigationMode == System.Windows.Navigation.NavigationMode.Back && _usedWebBrowserTask)
        {
            //Do your stuff here
            _usedWebBrowserTask = false;
        }
        base.OnNavigatedTo(e);
    }
    private void LaunchWebBrowserButton_Click(object sender, RoutedEventArgs e)
    {
        _usedWebBrowserTask = true;
        new WebBrowserTask()
        {
            Uri = new Uri("http://www.microsoft.com")
        }.Show();
    }
