    public class SuperClass
    {
    	public bool GenericTest<T>(T obj2)
    	{
    	   return ObjExt.GenericTest(obj2, obj2);
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
    
    public static class ObjExt
    {
    	public static bool GenericTest<T>(this T obj1, T obj2)
    	{
    		return true;
    	}
    }
