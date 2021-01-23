    public IBus Bus { get; internal set; }
    private readonly IUnityContainer _unityContainer;
    private readonly IHandlerRegistrator _handlerRegistrator;
    public UnityContainerAdapter(IUnityContainer unityContainer)
    {
        _unityContainer = unityContainer;
        _handlerRegistrator = _unityContainer
            .AddNewExtension<AllThatImplements>()
            .Configure<IHandlerRegistrator>();
    }
    public IEnumerable<IHandleMessages> GetHandlerInstancesFor<T>()
    {
        return _unityContainer.ResolveAll<IHandleMessages<T>>();
    }
    public void Release(IEnumerable handlerInstances)
    {
        foreach (IDisposable disposable in handlerInstances.OfType<IDisposable>())
            disposable.Dispose();
    }
    public void SaveBusInstances(IBus bus)
    {
        Bus = bus;
        _unityContainer.RegisterInstance(typeof(IBus), bus);
        _unityContainer.RegisterType<IMessageContext>(new InjectionMember[1]
        {
            new InjectionFactory(c => (object) MessageContext.GetCurrent())
        });
    }
    public UnityContainerAdapter Register<THandler>()
    {
        _handlerRegistrator.RegisterImplementingType<THandler>(typeof(IHandleMessages<>));
        return this;
    }
    public UnityContainerAdapter Handle<TMessage>(Action<TMessage> handler)
    {
        _unityContainer.RegisterType<IHandleMessages<TMessage>, HandlerMethodWrapper<TMessage>>(Guid.NewGuid().ToString(), new InjectionConstructor(handler));
        return this;
    }
    internal class HandlerMethodWrapper<T> : IHandleMessages<T>
    {
        private readonly Action<T> _action;
        public HandlerMethodWrapper(Action<T> action)
        {
            _action = action;
        }
        public void Handle(T message)
        {
            _action(message);
        }
    }
    public void Dispose()
    {
        _unityContainer.Dispose();
    }
    #region - Unity Extionsion -
    internal class AllThatImplements : UnityContainerExtension, IHandlerRegistrator
    {
        protected override void Initialize() { }
        public void RegisterImplementingType<T>(Type implementationToLookFor)
        {
            var closedType = typeof(T);
            closedType.GetInterfaces()
                      .Where(x => x.IsGenericType)
                      .Where(x => x.GetGenericTypeDefinition() == implementationToLookFor)
                      .ToList()
                      .ForEach(x => Container.RegisterType(x, closedType, Guid.NewGuid().ToString()));
        }
    }
    internal interface IHandlerRegistrator : IUnityContainerExtensionConfigurator
    {
        void RegisterImplementingType<T>(Type inheritedTypeToLookFor);
    }
    #endregion
}
