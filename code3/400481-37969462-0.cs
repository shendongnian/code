    public static class FunqExtensions
    {
        private static readonly ConcurrentDictionary<Type,ConcurrentBag<string>> registrations = new ConcurrentDictionary<Type, ConcurrentBag<string>>();
        public static void RegisterOneOfMany<TBase, TImplementation>(this Container container, string name = null, ReuseScope scope  = ReuseScope.None) where TImplementation : TBase
        {
            if (name == null)
                name = Guid.NewGuid().ToString();
            var funq = Container.GenerateAutoWireFn<TImplementation>();
            container.Register<TBase>(name, (c) => funq(c))
              .ReusedWithin(scope);
            registrations.GetOrAdd(typeof(TBase), type => new ConcurrentBag<string>()).Add(name);
        }
        public static IEnumerable<T> ResolveAll<T>(this Container container)
        {
            ConcurrentBag<string> result;
            if (registrations.TryGetValue(typeof(T), out result))
            {
                var rator = result.GetEnumerator();
                while (rator.MoveNext())
                {
                    yield return container.ResolveNamed<T>(rator.Current);
                }
            }
        }  
    }
