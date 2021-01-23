    DispatcherTimer Timer = new DispatcherTimer()
    {
        Interval = TimeSpan.FromSeconds(4)
    };
    Timer.Tick += (s, e) =>
    {
        Timer.Stop();
        NavigationService.Navigate(new Uri("SecondPage.xaml"));        
    };
    Timer.Start();
