    namespace Main.Server.Foo
    {
    	public class User
    	{
    	}
    }
    
    namespace Main.Server.Boo
    {
    	public class User
    	{
    	}
    }
    
    namespace Main.Client
    {
    	public static class Usage
    	{
    		public static void Main()
    		{
    			var foo = new Server.Foo.User();
    			var boo = new Server.Boo.User();
    		}
    	}
    }
