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
    Container.Kernel.Resolver.AddSubResolver( new LogResolver( Kernel ) );
