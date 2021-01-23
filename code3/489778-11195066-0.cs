    public interface IFooGenerator
    {
        public Foo GenerateFoo();
    }
    
    interface ISerialFooGenerator : IFooGenerator { }
    
    interface IParallelFooGenerator : IFooGenerator { }
    
    public class FooGenerator : ISerialFooGenerator
    {
        public Foo GenerateFoo()
        {
            //TODO
            return null;
        }
    }
    
    public class IParallelFooGenerator<T> : IParallelFooGenerator
        where T : ISerialFooGenerator, new()
    {
        public Foo GenerateFoo()
        {
            //TODO
            return null;
        }
    }
