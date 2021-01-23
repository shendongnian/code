    public class EventSink
    {
        private static readonly IList<Action<string>> _listeners = new List<Action<string>>();
        public static void RegisterListener(Action<string> listener)
        {
            _listeners.Add(listener);
        }
        public static void RaiseEvent(string message)
        {
            foreach (var l in _listeners)
                l(message);
        }
    }
