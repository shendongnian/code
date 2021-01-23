    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            Bind<IManager>()
               .To<Manager>()
               .WithConstructorArgument("a", ..)
        }
    
        ...
    }
