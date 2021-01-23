    public void Register<T>(Func<IFactoryContext, T> factoryMethod)
    {
       _containerBuilder.Register<Func<Type, T>>(c =>
          request => {
              var ctx = c.Resolve<IComponentContext>();
              factoryMethod(new AutofacFactoryContext(ctx));
       });
    }
