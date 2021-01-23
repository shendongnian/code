    public class MyCallHandler : ICallHandler
    {
    	public MyCallHandler(Int32 value)
    	{
    		Order = value;
    	}
    
    	public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    	{
    		Console.WriteLine("Parameterised call handler!");
    		return getNext()(input, getNext);
    	}
    
    	public int Order { get; set; }
    }
