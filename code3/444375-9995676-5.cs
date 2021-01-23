    using SimpleInjector;
    using SimpleInjector.Extensions;
    Type providerType = Type.GetType(
        ConfigurationManager.AppSettings["provider"]);
    Type handlerType = Type.GetType(
        ConfigurationManager.AppSettings["handler"]);
    Type processorType = Type.GetType(
        ConfigurationManager.AppSettings["preProcessor"]);
    var container = new Container();
    container.Register(typeof(IProvider), providerType);
    container.Register(typeof(IHandler), handlerType);
    container.Register(typeof(IPreProcessor), processorType);
