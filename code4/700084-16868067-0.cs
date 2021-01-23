    public class Event
    {
         
    }
    public abstract class EventHandler
    {
        public abstract void Handle(Event e);
    }
    public class EventHandler<T> : EventHandler where T : Event
    {
        private readonly Action<T> _action;
        public EventHandler(Action<T> action)
        {
            _action = action;
        }
        public override void Handle(Event e)
        {
            _action((T) e);
        }
    }
    public static class EventRouter
    {
        private static readonly Dictionary<Type, List<EventHandler>> Handlers = new Dictionary<Type, List<EventHandler>>();
        public static void Register<T>(Action<T> handler) where T : Event
        {
            List<EventHandler> list = null;
            if(Handlers.TryGetValue(typeof(T), out list))
            {
                list.Add(new EventHandler<T>(handler));
                return;
            }
            Handlers[typeof(T)] = new List<EventHandler>() { new EventHandler<T>(handler)};
        }
        public static void Signal(Event e)
        {
            List<EventHandler> list = null;
            if(Handlers.TryGetValue(e.GetType(), out list))
            {
                list.ForEach(h => h.Handle(e));
            }
        }
        public static void Signal<T>(Action<T> init) where T : Event, new()
        {
            var e = new T();
            init(e);
            Signal(e);
        }
    }
