    public class FactoryMethodDelegateAttribute : Attribute
    {
    	public FactoryMethodDelegateAttribute(Type type, string factoryMethodField, Message.MessageType typeId)
    	{
    		this.TypeId = typeId;
    		var field = type.GetField(factoryMethodField);
    		if (field != null)
    		{
    			this.FactoryMethod = (Func<byte[], Message>)field.GetValue(null);
    		}
    	}
    
    	public Func<byte[], Message> FactoryMethod { get; private set; }
    	public Message.MessageType TypeId { get; private set; }
    }
    
    public class Message
    {
    	public enum MessageType
    	{
    		ChatMsg,
    	}
    }
    
    [FactoryMethodDelegate(typeof(ChatMsg), "FactoryMethodDelegate", Message.MessageType.ChatMsg)]
    public class ChatMsg : Message
    {
    	public static readonly MessageType MessageTypeId = MessageType.ChatMsg;
    	public static readonly Func<byte[], Message> FactoryMethodDelegate = buffer => new ChatMsg(buffer);
    	public ChatMsg(byte[] buffer)
    	{
    		this.Buffer = buffer;
    	}
    
    	private byte[] Buffer { get; set; }
     }
    
    public class TestClass
    {
    	private IEnumerable<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute : Attribute
    	{
    		return from a in AppDomain.CurrentDomain.GetAssemblies()
    			   from t in a.GetTypes()
    			   where t.IsDefined(typeof(TAttribute), inherit)
    			   select t;
    	}
    
    	[Test]
    	public void Test()
    	{
    		var buffer = new byte[1];
    		var mappings = new Dictionary<Message.MessageType, Func<byte[], Message>>();
    		IEnumerable<Type> types = this.GetTypesWith<FactoryMethodDelegateAttribute>(true);
    		foreach (var type in types)
    		{
    			var attribute =
    				(FactoryMethodDelegateAttribute)
    				type.GetCustomAttributes(typeof(FactoryMethodDelegateAttribute), true).First();
    
    			mappings.Add(attribute.TypeId, attribute.FactoryMethod);
    		}
    
    		var message = mappings[Message.MessageType.ChatMsg](buffer);
    	}
    }
