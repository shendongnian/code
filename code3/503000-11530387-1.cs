    void Main()
    {
    	dynamic dyn = new CombiningDynamic(new Foo { X = 3 }, new Bar { Y = 42 });
    	Console.WriteLine(dyn.X);
    	Console.WriteLine(dyn.Y);
    }
    
    public class Foo
    {
    	public int X {get;set;}
    }
    
    public class Bar 
    {
    	public int Y { get;set;}
    }
    
    public class CombiningDynamic : DynamicObject
    {
    	private object [] innerObjects;
    	
    	
    	public CombiningDynamic(params object [] innerObjects) 
    	{
    		this.innerObjects = innerObjects;
    		
    	}
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		foreach(var instance in innerObjects) 
    		{
    			Type t = instance.GetType();
    			PropertyInfo prop = t.GetProperty(binder.Name);
    			if (prop != null && prop.CanRead) 
    			{
    				result = prop.GetValue(instance, null);
    				return true;
    			}
    		}
    		result = null;
    		return false;
    	}
    }
