    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Region = RegionType.City_Town
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Content("Thanks for choosing " + model.Region.Value.ToString());
        }
    }
