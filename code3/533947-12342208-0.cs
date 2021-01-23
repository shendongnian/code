    public static class DelayedExecutionService
    {
        public static void DelayedExecute(Action action, int delay = 3)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (sender, e) => action();
            dispatcherTimer.Interval = new TimeSpan(0, 0, delay);
            dispatcherTimer.Start();
        }
    }
