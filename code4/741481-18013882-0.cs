    using System.Threading;
    class HardwareEvents
    {
        private SynchronizationContext context;
        private Timer timer;
        public HardwareEvents() 
        {
           context = SynchronizationContext.Current ?? new SynchronizationContext();
           timer = new Timer(TimerMethod, null, 0, 1000); // start immediately, 1 sec interval.
        }
        
         private void TimerMethod(object state)
         {
             bool hardwareStateChanged = GetHardwareState();
             if (hardwareStateChanged)
                 context.Post(s => StateChanged(this, EventArgs.Empty), null); 
         }
         public event EventHandler StateChanged;
         private bool GetHardwareState()
         {
            // do something to get the state here.
            return true;
         }
    }
