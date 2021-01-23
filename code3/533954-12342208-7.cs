    public static class DelayedExecutionService
    {
        public static void DelayedExecute(Action action, int delay = 3)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            
            EventHandler handler = null;
            handler = (sender, e) =>
            {
                // Stop the timer so it won't keep executing every X seconds
                // and also avoid keeping the handler in memory.
                dispatcherTimer.Tick -= handler;
                dispatcherTimer.Stop();
                // Perform the action.
                action();
            };
		
            dispatcherTimer.Tick += handler;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(delay);
            dispatcherTimer.Start();
        }
    }
