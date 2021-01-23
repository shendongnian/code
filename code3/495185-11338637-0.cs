    public delegate void Work();
    public class TimedThing {
        public int IntervalSecs;
        public DateTime NextFiring;
        public event Work OnWork;        
    }
