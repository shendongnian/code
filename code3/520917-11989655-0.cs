    Class MyClass
    {
        Timer timer = new Timer();
        
        public MyClass()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000;
        }
        
        void Record()
        {
            StartFunction();
            timer.Start();        
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
             timer.Stop();
             StopFunction();
        }
    }
