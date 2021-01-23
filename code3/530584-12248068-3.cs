    public interface IHandlerOf<in T> where T : Component
    {
        void DoWork(T component);
    }
    public class ComponentService
    {
        private readonly Dictionary<Type, IHandlerInvoker> _handlers = new Dictionary<Type, IHandlerInvoker>();
        public void Register(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsInterface)
                    continue;
                foreach (var interfaceType in type.GetInterfaces())
                {
                    if (!interfaceType.IsGenericType || interfaceType.GetGenericTypeDefinition() != typeof(IHandlerOf<>))
                        continue;
                    var componentType = interfaceType.GetGenericArguments()[0];
                    var instance = Activator.CreateInstance(type);
                    var method = instance.GetType().GetMethod("DoWork", new[] { componentType });
                    _handlers[componentType] = new ReflectionInvoker(instance, method);
                }
            }
        }
        public void Register<T>(IHandlerOf<T> handler) where T : Component
        {
            _handlers[typeof (T)] = new DirectInvoker<T>(handler);
        }
        #region Nested type: DirectInvoker
        private class DirectInvoker<T> : IHandlerInvoker where T : Component
        {
            private readonly IHandlerOf<T> _handler;
            public DirectInvoker(IHandlerOf<T> handler)
            {
                _handler = handler;
            }
            #region IHandlerInvoker Members
            public void Invoke(Component component)
            {
                _handler.DoWork((T) component);
            }
            #endregion
        }
        #endregion
        #region Nested type: IHandlerInvoker
        private interface IHandlerInvoker
        {
            void Invoke(Component component);
        }
        #endregion
        #region Nested type: ReflectionInvoker
        private class ReflectionInvoker : IHandlerInvoker
        {
            private readonly object _instance;
            private readonly MethodInfo _method;
            public ReflectionInvoker(object instance, MethodInfo method)
            {
                _instance = instance;
                _method = method;
            }
            #region IHandlerInvoker Members
            public void Invoke(Component component)
            {
                _method.Invoke(_instance, new object[] {component});
            }
            #endregion
        }
        #endregion
        public void Invoke(Component component)
        {
            IHandlerInvoker invoker;
            if (!_handlers.TryGetValue(component.GetType(), out invoker))
                throw new NotSupportedException("Failed to find a handler for " + component.GetType());
            invoker.Invoke(component);
        }
    }
    public class DbComponent : Component
    {
    }
    public class DbComponentHandler : IHandlerOf<DbComponent>
    {
        public void DoWork(DbComponent component)
        {
            // do db specific information here
            Console.WriteLine("some work done!");
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new ComponentService();
            service.Register(Assembly.GetExecutingAssembly());
            var dbComponent = new DbComponent();
            service.Invoke(dbComponent);
        }
    }
