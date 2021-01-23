    public class SuperClass
    {
    	public bool GenericTest<T>(T obj2)
    	{
    		return false;
    	}
    }
    
    public class MyClass : SuperClass
    {
    	public int Id { get; set; }
    
    	public bool SuperTest<T>(T obj2)
    	{
    		return this.GenericTest<T>(obj2);
    	}
    }
