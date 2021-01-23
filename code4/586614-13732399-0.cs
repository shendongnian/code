    public class Foo : IFoo
    {
    	public string Prop
    	{
    		get { return "Hello Foo"; }
    	}
    
    	string IFoo.Prop
    	{
    		get { return "Hello IFoo"; }
    	}
    }
    
    public static void SomeMethod<T>(T foo) where T : IFoo
    {
    	var prop = typeof(T).GetProperty("Prop");
    	Console.WriteLine(prop.GetValue(foo));
    }
