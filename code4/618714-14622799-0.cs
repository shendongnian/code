    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (ApplicationFirstLaunched() == true)
        {
           NavigationManager.Current.Navigate(ApplicationView.DemoView);
        }
    }
