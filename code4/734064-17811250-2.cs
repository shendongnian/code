    namespace Sessions
    {
    
        public interface ISession
        {
            bool IsActive { get; }
            TimeSpan DurationActive { get; }
        }
        
        internal class Session : ISession
        {
            private Stopwatch _stopwatch;
            private bool _isChargeable;
            
            public bool IsActive
            {
                get { return _stopwatch.IsRunning; }
            }
            public TimeSpan DurationActive
            {
                get { return _stopwatch.Elapsed;  }
            }
            internal Session()
            {
                _stopwatch = new Stopwatch();
            }
            
            internal void Activate()   
            {
                _stopwatch.Start();
            }
            
            internal void Deactivate()
            {
                _stopwatch.Stop();
            }
        }
        
        public sealed class SessionMediator
        {
            private static readonly SessionMediator _instance = new SessionMediator();
            public static ISession CreateSession()
            {
                return _instance.createSession();
            }
            
            public static void ActivateSession(ISession session)
            {
                _instance.activateSession((Session)session);
            }
            
            private Session _currentSession = null;
            
            private SessionMediator() { }
            private ISession createSession()
            {
                return new Session();
            }
            
            private void activateSession(Session session)
            {
                // Deactivate the current session
                if (_currentSession != null)
                    _currentSession.Deactivate();
                
                // Make the given session the current session
                _currentSession = session;
                // Activate the new current session
                if (_currentSession != null)
                    _currentSession.Activate();
            }
        }
    
    }
    
