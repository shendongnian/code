    builder.RegisterType<A>()
        .As<IA>()
        .OnActivating(e =>
    {
        e.Instance.PropertyB = e.Context.Resolve<BImpl1>();
        e.Instance.PropertyC = e.Context.Resolve<BImpl2>();
    });
