        System.Timers.Timer timer = null;
        void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Enabled = false;
            AnotherWindow window = new AnotherWindow();
            window.Show();
        }
