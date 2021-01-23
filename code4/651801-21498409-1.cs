        using Project.Details; //<-- this is my ViewModel namespace name
        using Newtonsoft.Json;
        using System.IO;
        using System.Threading.Tasks;
        
        namespace WebApplication.Controllers
        {
            public class JSONController : Controller
            {
                //
                // GET: /JSON/
                public async Task<ActionResult> Index()
                {
                    StreamReader file = new StreamReader("C:\\Users\\YourName\\etc\\File.json");
                    String json = await file.ReadToEndAsync();
        
                    var Project = JsonConvert.DeserializeObject<RootObject>(json);
                    
                    return View();
                }
        	}
        }
