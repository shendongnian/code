    public static class DispatcherExtensions
    {
        private static Dictionary<string, DispatcherTimer> timers =
            new Dictionary<string, DispatcherTimer>();
        private static readonly object syncRoot = new object();
        public static void DelayInvoke(this Dispatcher dispatcher, string namedInvocation,
            Action action, TimeSpan delay,
            DispatcherPriority priority = DispatcherPriority.Normal)
        {
            lock (syncRoot)
            {
                RemoveTimer(namedInvocation);
                var timer = new DispatcherTimer(delay, priority, (s, e) => action(), dispatcher);
                timer.Start();
                timers.Add(namedInvocation, timer);
            }
        }
        public static void CancelNamedInvocation(this Dispatcher dispatcher, string namedInvocation)
        {
            lock (syncRoot)
            {
                RemoveTimer(namedInvocation);
            }
        }
        private static void RemoveTimer(string namedInvocation)
        {
            if (!timers.ContainsKey(namedInvocation)) return;
            timers[namedInvocation].Stop();
            timers.Remove(namedInvocation);
        } 
    } 
