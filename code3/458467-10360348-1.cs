    class Manager
    {
        Dictionary<TConsumed, IConsumer> consumers = new ...
    
        /* Code for attaching ItemGenerated event handlers to clients */
    }
    
    class MyClient : IGenerator<string>, IConsumer<Foo>, IConsumer<Bar>
    {
        event IGenerator<string>.ItemGenerated ...
    
        void IConsumer<Foo>.Consume(...) ...
    
        void IConsumer<Bar>.Consume(...) ...
    }
