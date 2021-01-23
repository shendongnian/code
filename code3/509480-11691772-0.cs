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
