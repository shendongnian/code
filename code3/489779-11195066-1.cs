    public interface IFooGenerator
    {
        Foo GenerateFoo();
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
    
    public class ParallelFooGenerator<T> : IParallelFooGenerator
        where T : ISerialFooGenerator, new()
    {
        public Foo GenerateFoo()
        {
            //TODO
            return null;
        }
    }
