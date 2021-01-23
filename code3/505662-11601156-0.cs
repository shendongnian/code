    void Main()
    {
       
       var nohiding = new NoHiding();
       var hiding = new Hiding();
       
       nohiding.DoSomething(); // "Overridden Method"
       hiding.DoSomething(); // "Hidden Method"
       
       var nohidingAsBase = (Base) nohiding;
       var hidingAsBase = (Base) hiding;
       
       nohidingAsBase.DoSomething(); // "Overridden Method"
       hidingAsBase.DoSomething(); // "Base Method"
       
    }
    
    public class Base
    {
    	public virtual void DoSomething()
    	{
    		Console.WriteLine("Base Method");
    	}
    }
    
    public class NoHiding : Base
    {
    	public override void DoSomething()
    	{
    		Console.WriteLine("Overriden Method");
    	}
    }
    
    public class Hiding : Base
    {
    	new public void DoSomething()
    	{
    		Console.WriteLine("Hidden Method");
    	}
    }
