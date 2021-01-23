    void ReRegisterSingletons(IContainer container, List<Type> singletonTypes)
    {
         var builder= new ContainerBuilder();
         foreach(var type in singletonTypes)
         {
              var resolved = container.Resolve(type);
              var method = this.GetType().GetMethod("ReRegister").MakeGenericMethod(new []{type});
              method.Invoke(this, new []{resolved});
         }
         builder.Update(container);
    }
    void Register<T>(ContainerBuilder builder, object singleton)
    {
        var theObj = (T)singleton;
         //a typed lambda was the only way I could get both the class name and the interface names to resolve from the child scope. RegisterInstance still resolves from root, and the non-generic lamba register can resolve the class name from child scope but not the interface names...
        builder.Register(c => theObj).AsSelf().AsImplementedInterfaces();
    }
