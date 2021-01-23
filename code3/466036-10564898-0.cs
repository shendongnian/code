    public class SteerSettings
    {
        public SteerType Type { get; private set; }
        public int Interval { get; private set; }
    
        public SteerSettings(SteerType type, int interval)
        {
            Type = type;
            Interval = interval;
        }
    }
