    public interface IFoo
    {
        string Name { get; }
        IFooSerializer GetSerializer(string serializationStrategy);
    }
    public interface IFooSerializer
    {
        string Serialize(IFoo foo);
        IFoo Deserialize(string xml);
    }
    public class Foo : IFoo { /* Code omitted. */ }
    public class FooXmlSerializer : IFooSerializer { /* Code omitted. */ }
    public class FooJsonSerializer : IFooSerializer { /* Code omitted. */ }
