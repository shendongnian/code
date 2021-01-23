    public class MyBootstrapper: DefaultNancyBootstrapper
    {
        ConfigureApplicationContainer (TinyIoCContainer container)
        {
            //the .AsSingleton() instructs TinyIOC to make only one of those.
            container.Register<IMessageDeliverer>().AsSingleton();
            base.ConfigureApplicationContainer (container);            
        }
    }
