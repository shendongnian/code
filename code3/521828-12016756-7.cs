    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Badge badge = ...
            BasgeViewModel vm = new BasgeViewModel
            {
                Id = badge.Id,
                Name = badge.Name
            };
    
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
