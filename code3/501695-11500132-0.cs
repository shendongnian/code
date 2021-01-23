    Timer tmr = null;
        private void StartTimer()
        {
           Timer tmr = new Timer();
           tmr.Interval = 1000;
           tmr.Tick += new EventHandler<EventArgs>(tmr_Tick);
           tmr.Enabled = true;
        }
    
        void tmr_Tick(object sender, EventArgs e)
        {
            // Code with your loop here
        }
