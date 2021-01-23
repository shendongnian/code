    public class C
    {
    	public event DataEventHandler<string> E;
    	public event DataEventHandler<C, string> EWithSender;
    	
    	public void Go()
    	{
    		Console.WriteLine ("Calling event E...");
    
    		E.Fire("hello");
    		EWithSender.Fire(this, "hello");
    	}
    }
