    class MyCrudeTimer : IDisposable
    {
        public event EventHandler Alarm ;
        
        public TimeSpan Duration           { get ; private set ; }
        public bool     AutomaticallyReset { get ; private set ; }
        public bool     IsRunning          { get ; private set ; }
        private Thread           timerThread ;
        private ManualResetEvent start       ;
        
        private void TimerCore()
        {
            try
            {
                while ( start.WaitOne() )
                {
                    System.Threading.Thread.Sleep( Duration ) ;
                    Alarm( this , new EventArgs() ) ;
                }
            }
            catch ( ThreadAbortException )
            {
            }
            catch ( ThreadInterruptedException )
            {
            }
            return ;
        }
        
        public MyCrudeTimer( TimeSpan duration , bool autoReset )
        {
            if ( duration <= TimeSpan.Zero ) throw new ArgumentOutOfRangeException("duration must be positive","duration") ;
            
            this.Duration            = duration  ;
            this.AutomaticallyReset  = autoReset ;
            this.start               = new ManualResetEvent(false) ;
            
            this.timerThread         = new Thread( TimerCore ) ;
            this.timerThread.Start() ;
            
            return ;
        }
        
        public void Start()
        {
            if ( IsRunning ) throw new InvalidOperationException() ;
            IsRunning = true ;
            start.Set() ;
            return ;
        }
        
        public void Stop()
        {
            if ( !IsRunning ) throw new InvalidOperationException() ;
            IsRunning = false ;
            start.Reset() ;
            return ;
        }
        
        public void Dispose()
        {
            try
            {
                if ( this.timerThread != null )
                {
                    this.timerThread.Abort() ;
                    this.timerThread = null ;
                }
            }
            catch
            {
            }
            return ;
        }
    }
