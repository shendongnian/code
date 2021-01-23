    public class Program
    {
    	private static void Main(string[] args)
    	{
    		new MyClass().Test(z => SomeMethod(z));
    	}
    
    	private static void SomeMethod(IEnumerable<IProduct> myReference)
    	{
    		Parallel.ForEach(myReference, item =>
    		{
    			lock (myReference)
    			{
    				// Some stuff here
    			}
    		});
    	}
    }
