    public abstract class BaseClass
    {
    	public abstract int Sample { get; set; }
    }  
   
    public class ChildClass1 : BaseClass
    {
    	private static int mSample = 0;
    	public override int Sample 
        { 
            get { return mSample; }
    	    set { mSample = value; }
    	}
    }
    
    public class ChildClass2 : BaseClass
    {
    	private static int mSample = 0;
    	public override int Sample 
        { 
            get { return mSample; }
    	    set { mSample = value; }
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var a = new ChildClass1();
     		var b = new ChildClass1();
    		var c = new ChildClass2();
   
    		a.Sample = 10;
   
    		Console.WriteLine(a.Sample); // 10
    		Console.WriteLine(b.Sample); // 10
    		Console.WriteLine(c.Sample); // 0
    	}
    }  
