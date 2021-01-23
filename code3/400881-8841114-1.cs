    public sealed class MessageHeaders : ...
    {
       public void Add(MessageHeader header);
       public T GetHeader<T>(int index);
       public T GetHeader<T>(string name,string ns);
       //More members
    }
    public abstract class MessageHeader
    {...}
    
    public class MessageHeader<T>
    {
       public MessageHeader();
       public MessageHeader(T content);
       public T Content {get;set;}
       public MessageHeader GetUntypedHeader(string name,string ns);
       //More members
    }
