    [RouteArea("Api")]
    [RoutePrefix("Search")]
    public class SearchController : Controller 
    {
        [POST("Index")]
        public ActionResult Index() { }
        [GET("Something")] // yields ~/Api/Search/Something
        [GET("NoPrefix", IgnoreRoutePrefix = true)] // yields ~/Api/NoPrefix
        [GET("NoAreaUrl", IgnoreAreaUrl = true)] // yields ~/Search/NoAreaUrl
        [GET("Absolutely-Pure", IsAbsoluteUrl = true)] // yields ~/Absolutely-Pure 
        public ActionResult Something() {}
    }
