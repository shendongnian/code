    //in your Ninject bindings:
    kernel.Bind<DataAdapter>().ToSelf().InSingletonScope();
    kernel.Bind<PersonManager>().ToSelf().InSingletonScope();
    //to bind the interface
    kernel.Bind<IPersonManager>()
       .ToMethod(c =>{ 
          var adapter = kernel.Get<DataAdapter>();
          //this is why these fields would have to be public
          var arg1 = new ConstructorArgument("adUserName", adapter._adUserName)
          var arg2 = new ConstructorArgument("adPassword", adapter._adPassword)
          var arg3 = new ConstructorArgument("client", adapter.client)
          //the names of the arguments must match PersonManager's constructor
          c.Kernel.Get<PersonManager>(arg1, arg2, arg3);
       });
    
    //now in your DataAdapter, specify a constructor like this, and Ninject will provide:
    
    public DataAdapter(Func<IPersonManager> personFunc)
    {
       //_person should obviously not be instantiated where it's defined in this case
       _person = new Lazy<IPersonManager>(personFunc);
    }
