    interface IEventsAggregator
    {
        //sends message to network
        void Publish(object message);
        //adds object to the list of handlers
        void Subscribe(object listener);
        //removes object from the list of handlers
        void Unsubscribe(object listener);
    } 
    //listeners should implement this interface
    interface IListener<TMessage>
    {
        //handling logic for particular message
        void Handle(TMessgae message);
    }
