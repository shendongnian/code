    using SimpleInjector.Extensions;
    
    public static void main(string[] args)
    {
        var container = new Container();
        // Find all consumers    
        var consumers =
            from type in typeof(SomeClass).Assembly
            where typeof(IConsumer).IsAssignableFrom(type)
            where !type.IsAbstract
            where !type.IsGenericTypeDefinition
            select type;
    
        // register all consumers
        foreach (var consumer in consumer)
            container.Register(consumer);
    
        IServiceBus bus = ServiceBusFactory.New(sbc =>
        {
            //other configuration options
    
            sbc.Subscribe(subs =>
            {
                foreach (var consumer in consumer)
                    subs.Consumer(consumer);
            });
        });
        //now we add the bus
        container.RegisterSingle<IServiceBus>(bus);
    }
