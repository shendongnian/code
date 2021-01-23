    public static class AutofacExtensions
    {
        public static void RegisterOrdered<TService>(this ContainerBuilder builder, Action<IOrderedScope> setter)
        {
            var scope = new OrderedScope<TService>(builder);
            setter(scope);
            builder.Register(ctx => ctx.Resolve<IEnumerable<TService>>().OrderBy(x => scope.OrderedTypes[x.GetType()]));
        }
    
        private class OrderedScope<TService> : IOrderedScope
        {
            private readonly ContainerBuilder _builder;
            private int _order = 1;
    
            public OrderedScope(ContainerBuilder builder)
            {
                _builder = builder;
                OrderedTypes = new Dictionary<Type, int>();
            }
    
            public Dictionary<Type, int> OrderedTypes {get;}
    
            public IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> Register<T>()
            {
                OrderedTypes.Add(typeof(T), _order++);
                return _builder.RegisterType<T>().As<TService>();
            }
        }
    }
    
    public interface IOrderedScope
    {
        IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> Register<T>();
    }
