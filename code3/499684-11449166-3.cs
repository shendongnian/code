    public class MovieController : Controller
    {
    	private ObjectContextManager ctxManager;
    	
    	public MovieController(ObjectContextManager ctxManager)
    	{
    		this.ctxManager = ctxManager;
    	}
    
    	public ActionResult Index()
    	{
    		using(var ctx = ctxManager.GetSet<Movie>())
    		{
    			var movies = ctx.OrderBy(m => m.Title);
    			return View(movies);
    		}
    	}
    }
