    public class ServiceController : Controller 
    {
        public async Task<ActionResult> Index()
        {		
    		var service = new Service();
            await service.CallMethodAsync();	
    	    return View();
        }
    }
