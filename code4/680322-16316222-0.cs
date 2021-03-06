    public class SampleController : Controller
    {
    	[GET("Sample")]
    	public ActionResult Index() { /* ... */ }
    	
    	[POST("Sample")]
    	public ActionResult Create() { /* ... */ }
    	
    	[PUT("Sample/{id}")]
    	public ActionResult Update(int id) { /* ... */ }
    	
    	[DELETE("Sample/{id}")]
    	public string Destroy(int id) { /* ... */ }
    	
    	[Route("Sample/Any-Method-Will-Do")]
    	public string Wildman() { /* ... */ }
    }
