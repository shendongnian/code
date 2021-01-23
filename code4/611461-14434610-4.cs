        DispatcherTimer timer = null;
        void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += new EventHandler(timer_Elapsed);
            timer.Start();
        }
        void timer_Elapsed(object sender, EventArgs e)
        {
            timer.Stop();
            AnotherWindow window = new AnotherWindow();
            window.Show();
        }
