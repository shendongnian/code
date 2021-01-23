    var lazyDependency = new Lazy<IHeavyDependency>(() =>
        new RealHeavyDependency());
    Bind<IHeavyDependency>()
        .ToConstant(new LazyHeavyDependency(lazyDependency));
    // Load value in a background thread.
    Task.Factory.StartNew(() => lazy.Value);
