        private void InitTimer()
        {
            lTimer       = new Timer();
            lTimer.Interval = 2000; 
            lTimer.Tick += new EventHandler(Timer_Tick);
            lTimer.Start();
        }
