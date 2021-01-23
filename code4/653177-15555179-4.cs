    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel();
            model.Name = "Márcia";
            model.SpanHtml = "<span title='Márcia'>Márcia</span>";
            return View(model);
        }
    }
	
