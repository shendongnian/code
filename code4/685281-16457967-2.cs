    public class FooProvider
    {
        public static Provider<T> Get<T> { return new Provider<T>(); };
    }
    public class Provider<T>
    {
        public T CreateDirect()
        {
            return Activator.Create<T>();
        }
        public TDerived CreateDerived<TDerived>() where TDerived : T
        {
            return Activator.Create<TDerived>();
        }
    }
