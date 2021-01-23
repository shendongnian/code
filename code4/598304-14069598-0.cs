        Timer timer = new Timer();
        timer.Tick += new EventHandler(timer_Tick);     // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * (50);             // Timer will tick every 50 second
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
        
        void timer_Tick(object sender, EventArgs e)
        {
            SendKeys.Send({NUMPAD5});
        }
