    public interface IPresentationEventArgs { }
    public abstract class PresentationEvent<TPresentationEventArgs> where TPresentationEventArgs : IPresentationEventArgs
    {
        private readonly List<Action<TPresentationEventArgs>> _subscribers = new List<Action<TPresentationEventArgs>>();
        public void Subscribe(Action<TPresentationEventArgs> action)
        {
            _subscribers.Add(action);
        }
        public void Publish(TPresentationEventArgs message)
        {
            foreach (var sub in _subscribers)
            {
                sub.Invoke(message);
            }
        }
    }
    public class MessageChangedEventArgs : IPresentationEventArgs 
    {
        public string Message { get; set; }
    }
    public class MessageChangedEvent : PresentationEvent<MessageChangedEventArgs>
    {
    }
    public static class EventBus
    {
        private static readonly Dictionary<Type, Func<Object>> _mapping = new Dictionary<Type, Func<Object>>();
        private static T GetPresentationEvent<T, TArgs>()
            where T : PresentationEvent<TArgs>, new()
            where TArgs : IPresentationEventArgs
        {
            if (_mapping.ContainsKey(typeof(T)))
            {
                return _mapping[typeof(T)]() as T;
            }
            var presEvent = new T();
            _mapping.Add(typeof(T), () => presEvent);
            return presEvent;
        }
        public static void Subscribe<T, TArgs>(Action<TArgs> action) where T : PresentationEvent<TArgs>, new()
            where TArgs : IPresentationEventArgs
        {
            var presEvent = GetPresentationEvent<T, TArgs>();
            presEvent.Subscribe(action);
        }
        public static void Publish<T, TArgs>(TArgs args) where T : PresentationEvent<TArgs>, new()
            where TArgs : IPresentationEventArgs
        {
            var presEvent = GetPresentationEvent<T, TArgs>();
            presEvent.Publish(args);
        }
    }
