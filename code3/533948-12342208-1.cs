    public static class DelayedExecutionService
    {
        public static void DelayedExecute(Action action, int delay = 3)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (sender, e) =>
            {
                // Perform the action.
                action();
                // Stop the timer so it won't keep executing every X seconds.
                dispatcherTimer.Stop();
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, delay);
            dispatcherTimer.Start();
        }
    }
