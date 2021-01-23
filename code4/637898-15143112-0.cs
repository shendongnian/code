    IUnityContainer container = new UnityContainer();
    string customerNamespace = ConfigurationManager.AppSettings["CustomerNamespace"];
    container.RegisterType(typeof(ISomeInterface), 
                           Type.GetType(customerNamespace+".SomeImplementation"));
    // ...
    ISomeInterface instance = conainer.Resolve<ISomeInterface>();
