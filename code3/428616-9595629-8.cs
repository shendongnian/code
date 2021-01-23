    public static class IPresentationEventArgsExtensions
    {
        public static void SubscribeTo<TEvent, TArgs>(this TEvent target, Action<TArgs> action)
            where TArgs : IPresentationEventArgs
            where TEvent : PresentationEvent<TArgs>, new()
        {
            EventBus.Subscribe<TEvent, TArgs>(action);
        }
    }
    // Use
     Action<MessageChangedEventArgs> messageChangedMethod = OnMessageChanged; // The compiler cannot infer that OnMessageChanged is a Action<IPresentationEventArgs>
     new MessageChangedEvent().SubscribeTo(messageChangedMethod);
