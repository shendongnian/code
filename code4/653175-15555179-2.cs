    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel();
            model.Name1 = "Márcia";
            model.Name2 = "M&#225;rcia";
            return View(model);
        }
    }
	
