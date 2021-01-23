    void Main()
    {
    	Derived dr = Base.GetDerived<Derived>();
    }
    
    public class Base
    {
    	public int ID { get; set; }
    	public Base()
    	{
    	
    	}
    	
    	public static T GetDerived<T>() where T : Base
    	{
    		T toReturn = (T)typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null);
    		return toReturn;
    	}
    
    }
    
    public class Derived : Base
    {
    	private Derived()
    	{
    	
    	}
    }
