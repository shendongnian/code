    public class MyTimer
    {    
        System.Threading.Timer timer;
        bool enabled;
        TimeSpan interval;
        public event EventHandler Tick;
    
        public MyTimer(TimeSpan interval)
        {
            enabled = true;
            this.interval = interval;
            timer = new Timer(TimerCallback, null, 1000, (int)interval.TotalSeconds);
        }
    
        private void TimerCallback(object state)
        {
            if (!enabled)
               return;
    
            if (Tick != null)
                Tick(this, EventArgs.Empty);          
        }
    
        public void Stop()
        {
            timer.Dispose();
            timer = null;
            enabled = false;
        }
        public void Start()
        {
            enabled = true;
            timer = new Timer(TimerCallback, null, 1000, (int)interval.TotalSeconds);
        }
    }
