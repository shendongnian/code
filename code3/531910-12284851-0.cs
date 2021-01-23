        // This timer runs on UI thread
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        timer.Interval = System.TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        timer.Start();
        void timer_Tick(object sender, System.EventArgs e)
        {
            Title = System.Windows.Input.Keyboard.FocusedElement.GetType().ToString();
        }
