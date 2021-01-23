    public class FooRegistry:Registry
    {
        public FooRegistry()
        {
            For(typeof(IFoo<>)).Use(x =>
            {
                var ParamType = x.BuildStack.Current.RequestedType
                                 .GetGenericArguments()[0];
                return BuildUsingFooFactory(ParamType);
            });
        }
        private object BuildUsingFooFactory(Type paramType)
        {
            var factoryType = typeof (FooFactory<>).MakeGenericType(new[] {paramType});
            var createMethod = factoryType.GetMethod("Create");
            object factory = Activator.CreateInstance(factoryType);
            return createMethod.Invoke(factory, new[] {"SomeParameterString"});
        }
    }
    public class FooFactory<T>
    {
        public IFoo<T> Create(string param)
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
