    public class HomeController : Controller
    {
        private IMemoryCacheService memoryCacheService;
        public HomeController(IMemoryCacheService memoryCacheService)
        {
            this.memoryCacheService = memoryCacheService;
        }
        public ActionResult Foo()
        {
            // use this.memoryCacheService in your controller methods...
        }
        ...
    }
