    public static class DelayedExecutionService
    {
        // We keep a static list of timers because if we only declare the timers
        // in the scope of the method, they might be garbage collected prematurely.
        private static IList<DispatcherTimer> timers = new List<DispatcherTimer>();
        public static void DelayedExecute(Action action, int delay = 3)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            // Add the timer to the list to avoid it being garbage collected
            // after we exit the scope of the method.
            timers.Add(dispatcherTimer);
            
            EventHandler handler = null;
            handler = (sender, e) =>
            {
                // Stop the timer so it won't keep executing every X seconds
                // and also avoid keeping the handler in memory.
                dispatcherTimer.Tick -= handler;
                dispatcherTimer.Stop();
                // The timer is no longer used and shouldn't be kept in memory.
                timers.Remove(dispatcherTimer);
                // Perform the action.
                action();
            };
		
            dispatcherTimer.Tick += handler;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(delay);
            dispatcherTimer.Start();
        }
    }
