    using Autofac;
    ...
    public override bool IsValid(object value)
    {
        using (var lifetimeScope = MvcApplication.Container.BeginLifetimeScope())
        {
            var repo = lifetimeScope.Resolve<IMyRepo>();
            // Do your validation checks which require the repo here
        } // The repo will be released / disposed here
    }
