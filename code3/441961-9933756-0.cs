    public class MyTimer
    {
        private SynchronizationContext synchronizationContext;
    
        public MyTimer() : this(SynchronizationContext.Current)
        {
        }
    
        public MyTimer(SynchronizationContext synchronizationContext)
        {
            if(this.synchronizationContext == null)
            {
                throw new ArgumentNullException("No synchronization context was specified and no default synchronization context was found.")
            }
        
            TimerElapsedHandler f = new TimerElapsedHandler(NotifyTimeChanged);
            TimeSpan period = new TimeSpan(0, 0, 1);
            ThreadPoolTimer.CreatePeriodicTimer(f, period);
        }
        private void NotifyTimeChanged()
        {
            if(this.PropertyChanged != null)
            {
                this.synchronizationContext.Post(() =>
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Time"));
                    });
            }
        }
    }
