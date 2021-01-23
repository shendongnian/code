    public class HomeController : Controller
    {
        public FooViewModel Foo { get; set; }
    
        [RequiresModel("Foo")]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
    
            return View();
        }
    }
