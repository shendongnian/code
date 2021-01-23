    class DoStuff
    {
        Func<string, IBusinessContext>> contextFunc;
    
        DoStuff(Func<string, IBusinessContext>> contextFunc)
        {
            this.contextFunc = contextFunc;
        }
    
        void SomeMethod()
        {
            var configuredValue = GetConfiguredValueSomehow();
            var context = contextFunc(configuredValue); //<-- this passes your config value back to ninject in the ToMethod() lambda
            //do something with context
        }
    }
