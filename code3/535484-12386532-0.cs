    public class SomeBaseClass {
       public SomeBaseClass (string activeId) {
       }
    }
        
    public interface ICallbackMessageBase { } 
    public class Foo : ICallbackMessageBase { } 
    internal sealed class GenericCallbackClass<ICallbackMessageBase> : SomeBaseClass
    {
    	public GenericCallbackClass(string activeId, ICallbackMessageBase message)
    		: base(activeId)
    	{
    	    Message = message;
    	}
    
    	public ICallbackMessageBase Message { get; private set; }
    }
    void Main()
    {
    	var specific = new GenericCallbackClass<ICallbackMessageBase>("foo", new Foo());
    }
