        internal class ConstantValueAccessor : IPropertyAccessor
        {
            private static readonly
            ConcurrentDictionary<Type, SynchronizedCollection<IGetter>> _getters =
                new ConcurrentDictionary<Type, SynchronizedCollection<IGetter>>();
            public static void RegisterGetter(Type type, IGetter getter)
            {
                var getters =
                    _getters.GetOrAdd(type,
                                      t => new SynchronizedCollection<IGetter>());
                getters.Add(getter);
            }
            public IGetter GetGetter(Type theClass, string propertyName)
            {
                SynchronizedCollection<IGetter> getters;
                if (!_getters.TryGetValue(theClass, out getters))
                    return null;
                return getters.SingleOrDefault(x => x.PropertyName == propertyName);
            }
            // ...
        }
