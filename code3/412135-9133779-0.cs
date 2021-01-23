    internal class Program
    {
    	private static Test test = new Test();
    	private static Action action = ActionHandler;
    
    	private static void ActionHandler()
    	{
            // Detaches the event handler
    		test.MyEvent -= test_MyEvent;
    	}
    
    	private static void Main(string[] args)
    	{
            // Attaches the event handler
    		test.MyEvent += test_MyEvent;
    
    		test.DoTheTest();
    
    		Console.ReadKey();
    	}
    
    	private static void test_MyEvent(object sender, EventArgs e)
    	{
            // Executes the method defined in the Action
    		action();
    	}
    }
    public class Test
    {
    	public event EventHandler MyEvent;
    
    	public void DoTheTest()
    	{
    		if (this.MyEvent != null)
    		{
    			this.MyEvent(this, EventArgs.Empty);
    		}
    	}
    }
