    public Class SampleClass
    (
    	private string testName;
    	public string ReturnName
    	{
    		private set { testName = "MyName"; }
    		get { return testName; }
    	}
    	
    	public void MethodName()
    	{
    		ReturnName = "hello";
    		Console.WriteLine(ReturnName);
    	}
    )
    
    public class Main
    {
    	SampleClass _x = new SampleClass();
    	Console.WriteLine(_x.ReturnName); // will output EMPTY
    	_x.MethodName(); // will output MyName
    }
