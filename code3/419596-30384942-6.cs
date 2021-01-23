    // Maps scopes to data "factories".
    public static class ScopedDataExtensions
    {
        private static readonly ConcurrentDictionary<object, Func<Data>> _factories = new ConcurrentDictionary<object, Fund<Data>>();
        public static Func<Data> GetFactory(this IComponentContext ctx) 
        {
            var factory = default(Func<Data>);
            return _factories.TryGetValue(ctx.ComponentRegistry, out factory) ? factory : () => null;
        }
        public static void SetFactory(this ILifetimeScope scope, Func<Data> factory)
        {
            _factories[scope.ComponentRegistry] = factory;
        }
    }
