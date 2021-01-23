    void Main()
    {
    	var a = new AProxy(new C(), new B());
    	for (int i = 0; i < 15; i++)
    	{
    		a.method1();
    		a.method2();
    	}
    }
    public abstract class A
    {
    	public abstract bool method1();
    	public abstract bool method2();
    }
    public class AProxy : A
    {
    	readonly A primary;
    	readonly A secondary;
    	public AProxy(A primary, A secondary)
    	{
    		this.primary = primary;
    		this.secondary = secondary;	
    		if(primary is IReturnsNulls)
    			((IReturnsNulls)primary).LastResultNull += (s, e) =>
    				useSecondary = true;
    	}
    	private bool useSecondary;
    	private bool UseSecondary
    	{
    		get 
    		{
    			if(useSecondary == true)
    			{
    				useSecondary = false;
    				return true;
    			}
    			return useSecondary;
    		}
    	}
    	public override bool method1()
    	{
    		var result = primary.method1();
    		return UseSecondary ? secondary.method1() : result;
    	}
    	public override bool method2()
    	{
    		var result = primary.method2();
    		return UseSecondary ? secondary.method2() : result;
    	}
    }
    public class B : A
    {
    	public override bool method1()
    	{
    		Console.WriteLine ("B, method1 (secondary)");
    		return true;
    	}
    	public override bool method2()
    	{
    		Console.WriteLine ("B, method2 (secondary)");
    		return true;
    	}
    }
    public interface IReturnsNulls
    {
    	event EventHandler LastResultNull;
    }
    public class C : A, IReturnsNulls
    {	
    	static Random random = new Random();
    	public override bool method1()
    	{
    		Console.WriteLine ("C, method1");
    		var result = (random.Next(5) == 1) ? (bool?)null : true;
    		if(result == null && LastResultNull != null)
    			LastResultNull(this, EventArgs.Empty);
    		return result ?? false;
    	}
    	public override bool method2()
    	{
    		Console.WriteLine ("C, method2");
    		var result = (random.Next(5) == 1) ? (bool?)null : true;
    		if(result == null && LastResultNull != null)
    			LastResultNull(this, EventArgs.Empty);
    		return result ?? false;
    	}
    	public event EventHandler LastResultNull;
    }
