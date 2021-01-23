    private void butStartAllClick(object sender, RoutedEventArgs e)
    {
        butStartAll.Content = "Running";
        LEDInitializing.Visibility = Visibility.Visible;
        lblInitializing.Visibility = Visibility.Visible;
        Task.Run(() =>
        {
            Init();
            //...rest of code
        });
    }
