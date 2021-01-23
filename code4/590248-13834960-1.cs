    [RouteArea("Api")]
    [RoutePrefix("Search")]
    public class SearchController : Controller 
    {
        [POST("Index")]
        public ActionResult Index() { }
        // Other actions to prefix....
    }
