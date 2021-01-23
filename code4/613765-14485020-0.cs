        using System.Linq;
        using log4net;
        public class LogInjectionModule : Module
        {
            protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
            {
                registration.Preparing += OnComponentPreparing;
                registration.Activating += OnComponentActivating;
            }
            private static void OnComponentActivating(object sender, ActivatingEventArgs<object> e)
            {
                InjectLogProperties(e.Context, e.Instance, false);
            }
            private static void OnComponentPreparing(object sender, PreparingEventArgs e)
            {
                e.Parameters = e.Parameters.Union(new[]
                    {
                        new ResolvedParameter(
                           (p, i) => p.ParameterType == typeof(ILog),
                           (p, i) => LogManager.GetLogger(p.Member.DeclaringType))
                    });
            }
            private static void InjectLogProperties(IComponentContext context, object instance, bool overrideSetValues)
            {
                if (context == null) throw new ArgumentNullException("context");
                if (instance == null) throw new ArgumentNullException("instance");
                var instanceType = instance.GetType();
                var properties = instanceType
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(pi => pi.CanWrite && pi.PropertyType == typeof(ILog));
                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length != 0)
                        continue;
                    var accessors = property.GetAccessors(false);
                    if (accessors.Length == 1 && accessors[0].ReturnType != typeof(void))
                        continue;
                    if (!overrideSetValues &&
                        accessors.Length == 2 &&
                        (property.GetValue(instance, null) != null))
                        continue;
                    ILog propertyValue = LogManager.GetLogger((instanceType);
                    property.SetValue(instance, propertyValue, null);
                }
            }
        }
