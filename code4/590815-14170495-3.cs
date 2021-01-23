    var builder = new ContainerBuilder();
    // Simple bit, register implementations for viewmodel, services
    builder.RegisterType<MainWindowViewModel>.As<IMainWindowViewModel>();
    builder.RegisterType<SubView1Model>.As<ISubView1Model>();
    builder.RegisterInstance<FooService>.As<IFooService>();
    // ok, lemme see if I can remember expression syntax...
    // Simple case: 'static' resolution of subview
    // We want a func that takes no args and returns us a fully-initialized
    //  SubView1
    builder.Register<Func<SubView1>>(context =>
    {
        // Since all the bits of a subview1 are registered, simply
        // resolve it and return
        var view = context.Resolve<SubView1>();
        return () => view;
    });
    // Complicated case - lets say this viewmodel depends
    // on foo service, which it uses to determine which 
    // bar service to use
    builder.Register<Func<IFooService, SubView2>>(context =>
    {
        // resolve our fooservice
        var service = context.Resolve<IFooService>();
        // and our view model
        var vm = context.Resolve<ISubView2ViewModel>();
        return (barService) =>
        {
            var barService = new BarService(service);
            return new SubView2(vm, barService);
        };
    });
  
