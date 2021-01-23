    static class Bus<T>
    {
        public static Dictionary<object, Action<object, T>> Subscriptions = new Dictionary<object, Action<object, T>>();
        public static void Raise(object sender, T message)
        {
            foreach (Action<object, T> action in Subscriptions.Values)
            {
                action(sender, message);
            }
        }
        public static void Subscribe(object subscriber, Action<object, T> action)
        {
            Subscriptions[subscriber] = action;
        }
        public static void Unsubscribe(object subscriber)
        {
            if (Subscriptions.ContainsKey(subscriber))
                Subscriptions.Remove(subscriber);
        }
    }
    
    public class WasModified { }
