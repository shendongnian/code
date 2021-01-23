    public class TextBoxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult TextBox(MvcApplication1.Models.TextBoxModel model)
        {
            return View(model);
        }
    
    }
