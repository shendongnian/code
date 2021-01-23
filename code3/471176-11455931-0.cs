    public class SomeClass
    {
         Lazy<List<string>> myLazy = new Lazy<List<string>>(LoadData);
         private List<string> LoadData()
         {
            //open connection, execute your query, read/project data into a List, etc
    	
    	    return new List<string> { "Hello", "My", "Name", "Is", "Earl" };
         }
    }
