    namespace MyProject.Core.Db
    {
    	public class User
    	{
    	}
    }
    
    namespace MyProject.Core.Model
    {
    	public class User
    	{
    	}
    }
    
    namespace MyProject.BLL
    {
    	public class Logic
    	{
    		public static void DoSomething()
    		{
    			var foo = new Core.Db.User();
    			var boo = new Core.Model.User();
    		}
    	}
    }
