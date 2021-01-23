    void Main()
    {
        var firstUri= new Uri("http://www.gravatar.com/avatar/2e8b6a4ea2ee8aedc49e5e4299661543?s=128&d=identicon&r=PG");
        var secondUri= new Uri("http://www.gravatar.com/avatar/23333db13ce939b8a70fb36dbfd8f934?s=32&d=identicon&r=PG");
    
        var wnd = new Window();
        var pnl = new StackPanel();
        wnd.Content = pnl;
    
        var img = new Image()
        {
            Source = new BitmapImage(firstUri),
            Stretch = Stretch.UniformToFill,
        };
        wnd.Show();
        pnl.Children.Add(img);
        
        // Optional; just need something to change the img src
        Observable
            .Timer(TimeSpan.FromSeconds(2))
            // The next line is roughly equivalent to invoking on
            // the Dispatcher (i.e., marshalling back to the UI thread)
            .ObserveOn(new DispatcherScheduler(wnd.Dispatcher))
            .Subscribe(_ =>
            {
                img.Source = new BitmapImage(secondUri);
            });
    }
