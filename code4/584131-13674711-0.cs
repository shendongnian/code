    internal static class IOC
    {
        private static readonly IKernel _kernel;
        static IOC()
        {
            _kernel = new StandardKernel(new IModule[] {
                new SomethingModule(),
            });
        }
        static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
    internal sealed class SomethingModule : StandardModule
    {
        public override void Load()
        {
            Bind<ISomething>().To<ConcreteSomething>(
                new ConstructorParam("arg", "value"));
        }
    }
