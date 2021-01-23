    class Program
    {
        static void Main(string[] args)
        {
            // The concrete entity.
            IEntity entityMock = MockRepository.GenerateMock<IEntity>();
            entityMock.Stub(s => s.Name).Return("Adam");
            // The runtime type of the entity, this'll be typeof(a RhinoMocks proxy).
            Type dynamicType = entityMock.GetType();
            // Our open generic type.
            Type cacheType = typeof(ICache<>);
            // Get the generic type of ICache<DynamicProxyForIEntity> (our closed generic type).
            Type  genericType = cacheType.MakeGenericType(dynamicType);
            // Concrete instance of ICache<DynamicProxyForIEntity>.
            object stubbed = MockRepository.GenerateStub(genericType, null);
            // Because of the generic co-variance in ICache<out T>, we can cast our
            // dynamic concrete implementation down to a base representation
            // (hint: try removing <out T> for <T> and it will compile, but not run).
            ICache<IEntity> typedStub = (ICache<IEntity>)stubbed;
            // Stub our interface with our concrete entity.
            typedStub.Stub(s => s.Item).Return(entityMock);
            Console.WriteLine(typedStub.Item.Name); // Prints "Adam".
            Console.ReadLine();
        }
    }
    public interface ICache<out T>
    {
        T Item { get; }
    }
    public interface IEntity
    {
        string Name { get; }
    }
