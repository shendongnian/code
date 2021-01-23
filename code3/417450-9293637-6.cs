    // this method can just be a global method in you app somewhere
    static string GetConfigValue()
    {
        //something like
        return AppSetting.Get("config");
    }
    Bind<IBusinessContext>().To<ConcreteBusinessContext>().When(r => GetConfigValue() == "config1");
    Bind<IBusinessContext>().To<SomeOtherBusinessContext>().When(r => GetConfigValue() == "config2");
    
    class DoStuff
    {
        IBusinessContext context;
    
        DoStuff(BusinessContext context)
        {
            this.context = context;
        }
        
        void SomeMethod()
        {
            //use the context value as you normally would
        }
    }
