    protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Loaded += ScreenLoaded;
    }
    private void ScreenLoaded(object sender, RoutedEventArgs e)
    {
        btn_reset.IsEnabled = false;
        bool result = VisualStateManager.GoToState(btn_reset, "Normal", false);
    }
