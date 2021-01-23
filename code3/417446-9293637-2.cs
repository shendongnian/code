    Bind<IBusinessContext>().To<ConcreteBusinessContext>().Named("config1");
    Bind<IBusinessContext>().To<ConcreteBusinessContext>().Named("config2");
    
    Bind<Func<string, IBusinessContext>>().ToMethod(ctx => str => ctx.Kernel.Get<IBusinessContext>().Named(str));
    
    class DoStuff
        {
            Func<string, IBusinessContext>> contextFunc;
        
            DoStuff(Func<string, IBusinessContext>> contextFunc)
            {
                this.contextFunc = contextFunc;
            }
        
            void SomeMethod()
            {
                var configuredValue = "config1";
                var context = contextFunc(configuredValue); //<-- this will passthrough "config1" to the above ToMethod() method and ask for a IBusinessContext named "config1"
                
            }
        }
