    class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDependency>().To<EmptyDependency>();
            Bind<IDependency>().To<ConcreteDependency>().When(req =>req.ParentContext.Request.Service == typeof(B));
        }
    }
