    // Use this binding only where T : IFoo
    kernel.Bind(typeof(IRepository<>)).To(typeof(FooRepository<>))
       .When(r => typeof(IFoo).IsAssignableFrom(r.Service.GetGenericArguments()[0]));
    
    // Use this one only where T : IBar
    kernel.Bind(typeof(IRepository<>)).To(typeof(BarRepository<>))
      .When(r =>  typeof(IBar).IsAssignableFrom(r.Service.GetGenericArguments()[0]));
