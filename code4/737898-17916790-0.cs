    interface IEventsAggrgator
    {
        //fires an event, reperesented by specific message
        void Publish<TMessage>(TMessage message);
        //adds object to the list of subscribers
        void Subscribe(object listener);
        //remove object from the list of subscribers
        void Unsubscribe(object listener);
    }
    interface IHandler<TMessage>
    {
        //implement this in subscribers to handle specific messages
        void Handle(TMessage message);
    }
