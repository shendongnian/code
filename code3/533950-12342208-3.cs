    public static class DelayedExecutionService
    {
        public static void DelayedExecute(Action action, int delay = 3)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            
            EventHandler handler = null;
            handler = (sender, e) =>
            {
                // Perform the action.
                action();
                // Stop the timer so it won't keep executing every X seconds
                // and also avoid keeping the handler in memory.
                dispatcherTimer.Tick -= handler;
                dispatcherTimer.Stop();
            };
		
            dispatcherTimer.Tick += handler;
            dispatcherTimer.Interval = new TimeSpan(0, 0, delay);
            dispatcherTimer.Start();
        }
    }
