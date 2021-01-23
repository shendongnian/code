    public interface IWhatever { }
    public class Foo { }
    public class Foo2 : Foo, IWhatever { }
    
    public class Bar { }
    public class Bar2 : Bar { }
    public class Bar3 : Bar, IWhatever { }
    public interface IModelProvider<T>
    {
        U Create<U>() where U : T;
    }
    public class FooProvider : IModelProvider<Foo>
    {
        public U Create<U>() where U : Foo
        {
            // create a proper "U" - for example Foo or Foo2
            return Activator.CreateInstance<U>(); // simpliest
        }
    }
    public class BarProvider : IModelProvider<Bar>
    {
        public U Create<U>() where U : Bar
        {
            // create a proper "U" - for example Bar, Bar2 or Bar3
            // more verbose
            if (typeof(U) == typeof(Bar)) return (U)new Bar();
            if (typeof(U) == typeof(Bar2)) return (U)(object)new Bar2();
            if (typeof(U) == typeof(Bar3)) return (U)(object)new Bar3();
            throw new Exception();
        }
    }
    public class WhateverProvider : IModelProvider<IWhatever>
    {
        public U Create<U>() where U : IWhatever, new()
        {
            // create a proper "U" - for example Foo2 or Bar3
            return new U(); // really the simpliest
        }
    }
    public class ProviderFactory
    {
        public static IModelProvider<T> Get<T>()
        {
            // somehow choose a provider for T, dumb implementation just for example purposes
            if (typeof(T) == typeof(Foo)) return (IModelProvider<T>)new FooProvider();
            if (typeof(T) == typeof(Bar)) return (IModelProvider<T>)new BarProvider();
            if (typeof(T) == typeof(IWhatever)) return (IModelProvider<T>)new WhateverProvider();
            return null;
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
