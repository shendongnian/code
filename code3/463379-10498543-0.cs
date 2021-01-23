    public abstract class Entity
    {
        private static Dictionary<Type, Action> Subscribers
             = new Dictionary<Type, Action>();
    
        internal virtual void OnSaved()
        {
            OnSaved(GetType());
        }
        private OnSaved(Type type)
        {
            Action subscribed;
            Subscribers.TryGetValue(type, out subscribed);
            if (subscribed != null)
                subscribed();
        }
    
        public Subscribe(Type type, Action action)
        {
            Action subscribed;
            Subscribers.TryGetValue(type, out subscribed);
            Subscribers[type] = subscribed + action;
        }
    
        public Unsubscribe(Type type, Action action)
        {
            Action subscribed;
            Subscribers.TryGetValue(type, out subscribed);
            Subscribers[type] = subscribed - action;
        }
    }
