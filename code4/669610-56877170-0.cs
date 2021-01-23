    //Route all traffic through this controller with the base URL being the domain
    [Route("")]
    public class MyController : Controller
    {
    	//Define up to 5 optional  patrameters
    	[HttpGet("{a1?}/{a2?}/{a3?}/{a4?}/{a5?}")]
    	public async Task<JsonResult> APIGet(string a1 = "", string a2 = "", string a3 = "", string a4 = "", string a5 = "")
    	{
    		//Custom logic processing each of the route variables
    		return Json(new string[] { a1, a2, a3, a4, a5 });
    	}
    }
