    public class ReecesWatcher
    {
        public event EventHandler ActiveEvent;
        public event EventHandler InactiveEvent;
        protected virtual void OnInactive(EventArgs e)
        {
            // Fire the event using the () syntax. Fire it through
            // a test variable so that we can reliabilty test for null, 
            // if there are no subscribers.
            EventHandler inactiveEventTest = InactiveEvent;
            if (inactiveEventTest != null)
            {
                inactiveEventTest(this, new EventArgs());
            }
            
            do
            {
                var idle2 = GetIdleTime();
                GetIdleTime();
                System.Diagnostics.Debug.WriteLine(idle2);
            }
            while (timer.Interval > 5000);
        }
        protected virtual void OnActive(EventArgs e)
        {
            // Fire the event using the () syntax. Fire it through
            // a test variable so that we can reliabilty test for null, 
            // if there are no subscribers.
            EventHandler activeEventTest = ActiveEvent;
            if (activeEventTest != null)
            {
                activeEventTest(this, new EventArgs());
            }
            if (timer.Interval < 5000)
            {
                var idle3 = GetIdleTime();
                System.Diagnostics.Debug.WriteLine(idle3);
            }
        }
        // ... the rest of your class, where you call OnActive and OnInactive to 
        // cause the events to be fired.
    }
