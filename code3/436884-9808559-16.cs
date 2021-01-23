    public class LoggerResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;
        public LoggerResolver( IKernel kernel )
        {
            this.kernel = kernel;
        }
        public object Resolve( CreationContext context, ISubDependencyResolver contextHandlerResolver, Castle.Core.ComponentModel model, DependencyModel dependency )
        {
            return NLog.LogManager.GetLogger(model.Implementation.FullName);
        }
        public bool CanResolve( CreationContext context, ISubDependencyResolver contextHandlerResolver, Castle.Core.ComponentModel model, DependencyModel dependency )
        {
            return dependency.TargetType == typeof( ILogger );
        }
    }
    //Register the sub dependency resolver. This looks cleaner if you do it via a
    //Facility but that's a whole other class
    Container.Kernel.Resolver.AddSubResolver( new LoggerResolver( Kernel ) );
