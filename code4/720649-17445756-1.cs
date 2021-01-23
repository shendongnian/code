    interface IContext {
    }
    class MyDbContext : DbContext, IContext {
    }
    class YourModule : NinjectModule {
        protected override void Bind() {
            Bind<IContext>().To<MyDbContext>();
        }
    }
    // In your composition root somewhere
    var kernel = new StandardKernel(new NinjectModule[] { new YourModule() });
    // in your createdatasource method
    kernel.Get<IContext>();
