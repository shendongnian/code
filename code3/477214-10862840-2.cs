    namespace MyProject
    {
    	public class Films
    	{
    		public struct CategoryDetails
    		{
    		}
    
    
    		public void DoStuff()
    		{
    			//both are valid
    			var categorydetails = new CategoryDetails();
    			var otherdetails = new Films.CategoryDetails();
    		}
    
    	}
    }
