    class Program
    {
    	static void Main(string[] args)
    	{
    		Bar b = new Bar();
    		b.DoSomethingWithFoo(new
    		{
    			Foobar = Return<string>.Arguments<string>(r => "foo")
    		}.ActLike<IFoo>());
    	}
    }
    
    public interface IFoo
    {
    	string Foobar(String s);
    }
    
    public class Bar
    {
    	public void DoSomethingWithFoo(IFoo foo)
    	{
    		Console.WriteLine(foo.Foobar("Hello World"));
    	}
    }
