    [ProtoContract]
    [ProtoInclude(1, typeof(Message<Foo>))]
    .... More as needed
    [ProtoInclude(8, typeof(Message<Bar>))]
    public abstract class Message
    {   }
    [ProtoContract]
    public class Message<T> : Message
    {
        ...
    }
