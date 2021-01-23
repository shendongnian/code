    public class Session
    {
        public Session()
        {
            DurationActive = new TimeSpan();
        }
        
        private int _durationActiveSeconds = 0;
        
        public TimeSpan DurationActive
        {
            get
            {
                return new TimeSpan.FromSeconds(_durationActiveSeconds);
            }
        }
    }
    
    // I'd probably make this class a singleton
    public class ActiveSessionIncrementor
    {
        private Timer _timer;
        
        public Session ActiveSession { get; set; }
        
        public ActiveSessionIncrementor()
        {
            _timer = new Timer(1000); // 1 second accuracy is sufficient for me
            _timer.Elapsed += new ElapsedEventHandler(onTimedEvent);
            
        }
        
        private onTimedEvent()
        {
            if (ActiveSession != null)
                ActiveSession.ActiveDuration++;
        }
    }
