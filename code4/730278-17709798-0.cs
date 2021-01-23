    public class HomeController : BaseController
    {
         [GET("")]
         [GET("", IsAbsoluteUrl = true)]
         public ActionResult Index()
         {...
