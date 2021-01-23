    class Program
    {
        static void Main(string[] args)
        {
            var entityMock = MockRepository.GenerateMock<IEntity>();
            entityMock.Stub(s => s.Name).Return("Adam");
            var dynamicType = entityMock.GetType();
            var cacheType = typeof(ICache<>);
            // Get the generic type of ICache<DynamicProxyForIEntity>
            var genericType = cacheType.MakeGenericType(dynamicType);
            // Stub this new interface type using a non-generic GenerateStub.
            var stubbed = MockRepository.GenerateStub(genericType, null);
            // Because of the generic co-variance in ICache<out T>, we can do this
            // (hint: try removing <out T> for <T> and it will compile, but not run).
            var typedStub = (ICache<IEntity>)stubbed;
            // Stub our interface with our concrete entity.
            typedStub.Stub(s => s.Item).Return(entityMock);
            Console.WriteLine(typedStub.Item.Name);
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
