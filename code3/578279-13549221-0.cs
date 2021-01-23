    //ui
    void UILayer.ConfigureUnity(unity)
    {
        ServiceLayer.ConfigureUnity(unity)
    }
    //services
    void ServiceLayer.ConfigureUnity(unity)
    {
        DAL.ConfigureUnity(unity)
        unity.RegisterType<IMarketService, MarketService>();
        
    }
    //dal
    void DAL.ConfigureUnity(unity)
    {
        unity.RegisterType<IMarketRepository, MarketRespository>();
        unity.RegisterType<MyContext, MyContext>(); //not sure exact syntax - just register type for 'new Type()' activator.
    }
    
    
