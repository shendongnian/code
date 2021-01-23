    public class MyTimer : ITimer
    {
        private Timer timer = new Timer();
        public void Start(double interval)
        {
            timer.Interval = interval; 
            timer.Start();
        }
 
        public void Stop()
        {
            timer.Stop();
        }
        public event ElapsedEventHandler Elapsed
        {
            add { this.timer.Elapsed += value; }
            remove { this.timer.Elapsed -= value; }
        }
    }
