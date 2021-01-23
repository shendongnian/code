    public class FileUploadController : Controller
    {
        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            return Json("All files have been successfully stored."); 
        }
    }
