    public interface IBaseClass
    {
    	int GetHandlerID();
    }
    
    public abstract class AbstractClass : IBaseClass
    {
    	protected virtual int HandlerID { get; set; }
    
    	public virtual int GetHandlerID()
    	{
    		return (HandlerID);
    	}
    }
    
    public class MyClass : AbstractClass
    {
    	private int _handlerID = 1;
    	protected override int HandlerID { get { return _handlerID; } set { _handlerID = value; } }
    }
    
    
    private static void Main(string[] args)
    {
    	var newClass = new MyClass();
    	Console.WriteLine("HandlerID: {0}", newClass.GetHandlerID());
    	Console.ReadKey();
    }
