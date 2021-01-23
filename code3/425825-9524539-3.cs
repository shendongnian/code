    container.Register(Component.For<ILoggerProvider>().ImplementedBy<Log4NetLoggerProvider >().LifeStyle.Transient);
    public interface ICommonLoggerProvider
    {
        ICommonLog GetLogger( Type type );
    }
    public class Log4NetLoggerProvider : ICommonLoggerProvider
    {
        public ICommonLog GetLogger(Type type)
        {
            return new Log4NetLogger(type);
        }
    }
    public class LoggerResolver : ISubDependencyResolver
    {
        ...
        public object Resolve( CreationContext context, ISubDependencyResolver contextHandlerResolver, Castle.Core.ComponentModel model, DependencyModel dependency )
        {
            return kernel.Resolve<ICommonLoggerProvider>().GetLogger( model.Implementation );
        }
    }
