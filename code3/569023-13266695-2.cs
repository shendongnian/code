    public class DateWrapper
    {
        private ConcurrentBag<DateWrapper> list;
        private DateTime time;
        public DateTime Time
        {
            get { return time; }
        }
        private Timer timer;
        public DateWrapper(ConcurrentBag<DateWrapper> _list, DateTime _time)
        {
            list = _list;
            time = _time;
            list.Add(this);
            timer = new Timer();
            timer.Interval = 300000; // 5 Minutes
            timer.Tick += new EventHandler(Tick);
            timer.Start();
        }
        private void Tick(object sender, EventArgs e)
        {
            list.Remove(this);
        }
    }
