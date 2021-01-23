    Bind<Func<string, IBusinessContext>>().ToMethod(ctx => str => DetermineWhichConcreteTypeToLoad(ctx, str));
    
    //messy sudo code
    static DetermineWhichConcreteTypeToLoad(IContext ctx, string str)
    {
        if(str == "somevalue"){
            return ctx.Kernel.Get<ConcreteType1>();
        else
            return ctx.Kernel.Get<ConcreteType2>();
    }
