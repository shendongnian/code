    public static void Main(string[] args)
    {
        var container = new SimpleInjector.Container();
        
        BootstrapperModule.Register(container);
        ...
    }    
