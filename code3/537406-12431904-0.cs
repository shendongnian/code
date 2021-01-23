    private class SomeEventMonitor
    {
        public  int      Threshold       { get ; private set ; }
        public  TimeSpan ThresholdWindow { get ; private set ; }
        private DateTime  marker ;
        private int       count  ;
        /// <summary>
        /// public constructor
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="window"></param>
        public SomeEventMonitor( int threshold , TimeSpan window )
        {
            if ( threshold <  1             ) throw new ArgumentOutOfRangeException("threshold") ;
            if ( window    <= TimeSpan.Zero ) throw new ArgumentOutofRangeException("window") ;
            this.Threshold       = threshold ;
            this.ThresholdWindow = window    ;
            Reset() ;
            return ;
        }
        private void Reset()
        {
            this.marker       = DateTime.Now ;
            this.count        = 0            ;
            return ;
        }
        public event EventHandler ThresholdExceeded ;
        private static readonly object latch = new object() ;
        public void EventWatcher( object source , EventArgs eventArgs )
        {
            lock ( latch )
            {
                DateTime current = DateTime.Now ;
                
                if ( ++count > Threshold )
                {
                    TimeSpan window = current -marker ;
                    if ( window > ThresholdWindow )
                    {
                        ThresholdExceeded( this , new EventArgs() ) ;
                        Reset() ;
                    }
                }
                
            }
            return ;
        }
        
    }
