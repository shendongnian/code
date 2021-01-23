        void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
