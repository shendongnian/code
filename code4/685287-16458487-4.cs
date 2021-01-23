    public class ProviderFactory
    {
        public static IModelProvider<T> Get<T>() where T : new()
        {
            // somehow choose a provider for T, dumb implementation just for example purposes
            if (typeof(T) == typeof(Foo)) return (IModelProvider<T>)new FooProvider();
            if (typeof(T) == typeof(Bar)) return (IModelProvider<T>)new BarProvider();
            if (typeof(T) == typeof(IWhatever)) return (IModelProvider<T>)new WhateverProvider();
            return VeryGenericProvider<T>();
        }
    }
    public static class ProviderTest
    {
        public static void test()
        {
            Foo foo = ProviderFactory.Get<Foo>().Create<Foo>();
            Foo2 foo2 = ProviderFactory.Get<Foo>().Create<Foo2>();
            // Bar2 bar2 = ProviderFactory.Get<Foo>().Create<Bar2>(); - compile error
            Bar2 bar2 = ProviderFactory.Get<Bar>().Create<Bar2>(); // - ok!
            Bar3 bar3 = ProviderFactory.Get<IWhatever>().Create<Bar3>();
        }
    }
