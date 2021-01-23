    void Main()
    {
    	"Test".Test();
    }
    static class Extensions
    {
    	public static void Test(this string s)
    	{
    		var method = new StackTrace().GetFrame(1).GetMethod();
    		Console.WriteLine(String.Format("I was called from '{0}' of class '{1}'", method.Name, method.DeclaringType));
    	}
    }
