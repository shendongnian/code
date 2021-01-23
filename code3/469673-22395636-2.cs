    public class FooRegistry:Registry
    {
        public FooRegistry()
        {
            For(typeof (IFooFactory<>))
                .Use(typeof (FooFactory<>))
                .CtorDependency<string>("connection")
                .Is("SomeConnectionString");
        }
    }
    public interface IFooFactory<T>
    {
        IFoo<T> CreateInstance();
    }
    public class FooFactory<T> : IFooFactory<T>
    {
        public FooFactory(string connection)
        {
        } 
        public IFoo<T> CreateInstance()
        {
            return new Foo<T>();
        }
    }
    public interface IFoo<T>
    {
    }
    public class Foo<T> : IFoo<T>
    {   
    }
