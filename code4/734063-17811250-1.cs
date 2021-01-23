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
            _timer.Start();
            
        }
        
        private onTimedEvent()
        {
            if (ActiveSession != null)
                ActiveSession.ActiveDuration++;
        }
    }
    
    public class Program
    {
        public void Main()
        {
            ActiveSessionIncrementor incrementor = new ActiveSessionIncrementor();
            
            Session session1 = new Session();
            Session session2 = new Session();
            Session session3 = new Session();
            
            incrementor.ActiveSession = session1;
            Thread.Sleep(2000);
            Debug.Assert(session1.DurationActive == TimeSpan.FromSeconds(2));
            
            increment.ActiveSession = session2;
            Thread.Sleep(3000);
            Debug.Assert(session2.DurationActive == TimeSpan.FromSeconds(3));
            
            increment.ActiveSession = session1;
            Thread.Sleep(3000);
            Debug.Assert(session1.DurationActive == TimeSpan.FromSeconds(5));
        }
    }
