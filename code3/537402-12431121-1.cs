        // First stab at an "expiring" type that is only valid for a set interval.
    public class Expiring<T>
    {
        public delegate void ExpiredHandler(object sender, EventArgs e);
        public event ExpiredHandler OnExpired;
            
        T instance;
        int signaledCount = 0;
        long milliseconds = 0;
        bool isExpired = false;
        bool exceptOnExpiredReference = true;
        System.Timers.Timer lapseTimer = new System.Timers.Timer();
        public Expiring(T value)
        {
            instance = value;
        }
        public virtual void TimerElapsed(object sender, System.Timers.ElapsedEventArgs args)
        {
            if (OnExpired != null)
            {
                OnExpired(this, null);
            }
            isExpired = true;
        }
        public Expiring(T startValue, long expirationInterval, bool throwElapsedReferenceException):this(startValue)
        {
            milliseconds = expirationInterval;
            lapseTimer.AutoReset = true;
            lapseTimer.Interval = milliseconds;
            exceptOnExpiredReference = throwElapsedReferenceException;
            lapseTimer.Elapsed+=new System.Timers.ElapsedEventHandler(TimerElapsed);
            this.Set();
        }
        
        public void Set()
        {
            signaledCount++;
            lapseTimer.Stop();
            lapseTimer.Start();
        }
        
        public T Value
        {
            get
            {
                if (!isExpired || !exceptOnExpiredReference)
                    return instance;
                else
                    throw new InvalidOperationException("Reference to an expired value.");
            }
            set
            {
                instance = value;
            }
        }
    }
