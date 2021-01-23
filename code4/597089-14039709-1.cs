    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ExportViewModel());
        }
        [HttpPost]
        public ActionResult Export(ExportViewModel model)
        {
            var cd = new ContentDisposition
            {
                FileName = "YourFileName.csv",
                Inline = false
            };
            Response.AddHeader("Content-Disposition", cd.ToString());
            return Content(model.Csv, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
