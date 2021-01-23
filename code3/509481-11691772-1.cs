    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => GetLogger(p.TypedAs<Type>()));
        }
        protected override void AttachToComponentRegistration(
            IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Preparing +=
                (sender, args) =>
                {
                    var forType = args.Component.Activator.LimitType;
                    var logParameter = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof (ILog),
                        (p, c) => c.Resolve<ILog>(TypedParameter.From(forType)));
                    args.Parameters = args.Parameters.Union(new[] {logParameter});
                };
        }
        public static ILog GetLogger(Type type)
        {
            return new Log4NetLogger(type);
        }
    }
    public interface ILog
	{
	    void Debug(string format, params object[] args);
        void Info(string format, params object[] args);
        void Warn(string format, params object[] args);
        
        void Error(string format, params object[] args);
        void Error(Exception ex);
        void Error(Exception ex, string format, params object[] args);
        void Fatal(Exception ex, string format, params object[] args);
	}
    public class Log4NetLogger : ILog
    {
        private readonly log4net.ILog _log;
        static Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }
        public Log4NetLogger(Type type)
        {
            _log = LogManager.GetLogger(type);
        }
        public void Debug(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }
        public void Info(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
        public void Warn(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }
        public void Error(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }
        public void Error(Exception ex)
        {
            _log.Error("", ex);
        }
        public void Error(Exception ex, string format, params object[] args)
        {
            _log.Error(string.Format(format, args), ex);
        }
        public void Fatal(Exception ex, string format, params object[] args)
        {
            _log.Fatal(string.Format(format, args), ex);
        }
    }
