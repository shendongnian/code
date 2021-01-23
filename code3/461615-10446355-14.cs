    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel());
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // validation failed => redisplay the view
                return View(model);
            }
            // the model is valid => we could process the file here
            var fileName = Path.GetFileName(model.File.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            model.File.SaveAs(path);
            return RedirectToAction("Success");
        }
    }
