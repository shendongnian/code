    public static class AutofacScopeExtensions
    {
        // Map from context => factories per type
        public static readonly ConcurrentDictionary<object, ConcurrentDictionary<Type, object>> _factories =
            new ConcurrentDictionary<object, ConcurrentDictionary<Type, object>>();
        private static class ScopedFactoryFor<T>
        {
            public static Func<T> DefaultFactory = () => default(T);
            public static Func<T> GetFactory(ConcurrentDictionary<Type, object> fromContext)
            {
                object factory;
                return (fromContext.TryGetValue(typeof(T), out factory)) ? (Func<T>)factory : DefaultFactory;
            }
        }
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> 
            WithContextFactoryFor<T>(this ContainerBuilder builder, Func<T> defaultFactory = null)
        {
            if (defaultFactory != null)
                ScopedFactoryFor<T>.DefaultFactory = defaultFactory;
            builder.Register<Func<T>>(AutofacScopeExtensions.GetFactory<T>);
            return builder.Register<T>(ctx => ctx.Resolve<Func<T>>()());
        }
        public static ILifetimeScope SetScopeFactory<T>(this ILifetimeScope scope, Func<T> factory)
        {
            ScopeMapFor(scope)[typeof(T)] = factory;
            return scope;
        }
        public static ILifetimeScope SetScopeValue<T>(this ILifetimeScope scope, T instance)
        {
            return SetScopeFactory(scope, () => instance);
        }
        public static Func<T> GetFactory<T>(IComponentContext ctx)
        {
            return ScopedFactoryFor<T>.GetFactory(ScopeMapFor(ctx));
        }
        private static ConcurrentDictionary<Type, object> ScopeMapFor(IComponentContext ctx)
        {
            return _factories.GetOrAdd(ctx.ComponentRegistry, x => new ConcurrentDictionary<Type, object>());
        }
        private static void OnScopeStarting(object sender, LifetimeScopeBeginningEventArgs evt)
        {
            evt.LifetimeScope.CurrentScopeEnding += OnScopeEnding; // so we can do clean up.
        }
        private static void OnScopeEnding(object sender, LifetimeScopeEndingEventArgs evt)
        {
            var map = default(ConcurrentDictionary<Type, object>);
            if (_factories.TryRemove(evt.LifetimeScope.ComponentRegistry, out map))
                map.Clear();
        }
    }
