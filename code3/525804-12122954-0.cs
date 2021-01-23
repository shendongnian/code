    public class BaseClass
    {
    	public virtual void Print()
    	{
    		Console.WriteLine("base print");
    	}
    	
    	public virtual void AnotherPrint()
    	{
    		Console.WriteLine("base another print");
    	}
    }
    
    public class SubClass : BaseClass
    {
    	public override void Print()
    	{
    		Console.WriteLine("sub print");
    	}
    	
    	public void AnotherPrint()
    	{
    		Console.WriteLine("sub another print");
    	}
    }
