    public class HomeController : BaseController
    {
        [HttpPost]
        public ActionResult Save(Thing model)
        {
            //model has CurrentUser and PersonalSettings set without any values being posted. You can also access the values on the BaseController if you don't want to automatically bind it.
            return View();
        }
    }
