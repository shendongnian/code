    class Form1 ...
    {
        private System.Timers.Timer timer = null;
        public void start()
        {
        if (timer == null)
            {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timerElapsed);
            }
        timer.Enabled = true;
        }
        
        ...
    }
