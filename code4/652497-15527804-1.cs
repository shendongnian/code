    public interface IFoo
    {
        string Name { get; }
        IFooSerializer GetSerializer(string format);
    }
    public enum FooSerializerFormat { Xml, Json };
    public interface IFooSerializer
    {
        string Serialize(IFoo foo);
        IFoo Deserialize(string xml);
    }
    public class Foo : IFoo
    {
        public string Name { get; }
        public IFooSerializer GetSerializer(FooSerializerFormat format)
        {
            case FooSerializerFormat.Xml:
                return new FooXmlSerializer();
            case FooSerializerFormat.Json:
                return new FooJsonSerializer();
        }
    }
    public class FooXmlSerializer : IFooSerializer { /* Code omitted. */ }
    public class FooJsonSerializer : IFooSerializer { /* Code omitted. */ }
