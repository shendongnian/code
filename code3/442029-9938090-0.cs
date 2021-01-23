    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileData)
        {
            if (fileData != null && fileData.ContentLength > 0)
            {
                var appData = Server.MapPath("~/app_data");
                var filename = Path.Combine(appData, Path.GetFileName(fileData.FileName));
                fileData.SaveAs(filename);
            }
            return Json(true);
        }
    }
