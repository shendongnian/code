    public class ActionHelper
    {
        private static Dictionary<Delegate, System.Threading.Timer> timers =
            new Dictionary<Delegate, System.Threading.Timer>();
        private static object lockObject = new object();
        public static void DelayAction(Action action, TimeSpan delay)
        {
            lock (lockObject)
            {
                System.Threading.Timer timer;
                if (!timers.TryGetValue(action, out timer))
                {
                    timer = new System.Threading.Timer(EventTimerCallback, action,
                        System.Threading.Timeout.Infinite,
                        System.Threading.Timeout.Infinite);
                    timers.Add(action, timer);
                }
                timer.Change(delay, TimeSpan.FromMilliseconds(-1));
            }
        }
        public static void EventTimerCallback(object state)
        {
            var action = (Action)state;
            lock (lockObject)
            {
                var timer = timers[action];
                timers.Remove(action);
                timer.Dispose();
            }
            action();
        }
    }
