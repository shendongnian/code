    public class MyPersonController : Controller {
    
    	public ActionResult Index() {
    		List<MyPerson> database = new List<MyPerson>();
    		BinaryFormatter formatter = new BinaryFormatter();
    		if (File.Exists(Database))
    		{ 
    			using (FileStream stream = System.IO.File.OpenRead(Database)) 
    			database = (List<MyPerson>)formatter.Deserialize(stream); 
    		}
    		
    		
    		return View(database);
    	}
    }
