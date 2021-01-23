    [RouteArea("Documentation")]
    public class DocumentationController : Controller
    {
        [GET("Index", Order = 1)] // will handle "/documentation/index"
        [GET("")] // will handle "/documentation"
        [GET("", IsAbsoluteUrl = true)] // will handle "/"
        public ActionResult Index()
        {
            return View();
        }
    }
