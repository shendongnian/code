    public class MyTimer : ITimer {
        Timer timer;
    
        // implement ITimer member
        public int Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
    }
