    namespace SandboxMvcApplication.Areas.Admin.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult List()
            {
                ViewBag.Message = "You've acessed Admin/List";
    
                return View();
            }
        }
    }
