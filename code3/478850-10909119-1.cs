    public class CustomBaseController : Controller
    {
    	protected override void OnResultExecuting(ResultExecutingContext context)
    	{   
    		HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
    		HttpContext.Current.Response.AddHeader("Cache-Control", "private"); //to be safe cross browser
    	}
    }
