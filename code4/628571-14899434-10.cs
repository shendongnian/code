    public class HomeController : Controller
    {
        private IMemoryCacheService memoryCacheService;
        private IEmailService emailService;
        public HomeController(IMemoryCacheService memoryCacheService, IEmailService emailService)
        {
            this.memoryCacheService = memoryCacheService;
            this.emailService = emailService;
        }
        public ActionResult Foo()
        {
            // use this.memoryCacheService in your controller methods...
            // and also use this.emailService in your controller methods...
        }
        ...
    }
