    public static void main(string[] args)
    {
        var container = new Container();
        var consumers = container.GetTypesToRegister(typeof(IConsumer),
            applicationAssemblies);
        foreach (Type consumer in consumers)
            container.Register(consumer);
    
        IServiceBus bus = ServiceBusFactory.New(sbc => {
            //other configuration options
    
            sbc.Subscribe(subs => {
                foreach (var consumer in consumers)
                    subs.Consumer(consumer);
            });
        });
        container.RegisterSingle<IServiceBus>(bus);
        container.Verify();
    }
