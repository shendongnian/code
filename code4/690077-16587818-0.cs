    public class ImagesController : Controller
        {
            [ActionName("PDF")]
            public ActionResult DownloadFile(string id)
            {
                if (id == null)
                    return new HttpNotFoundResult();
    
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
                string FileName = id;
 
                string FullFileLogicalPath = Path.Combine(ConfigurationManager.AppSettings["VIRTUAL_DIR_PATH"], FileName);
                string FullfilePhysicalPath = Path.Combine(ConfigurationManager.AppSettings["PHYSICAL_DIR_PATH"], FileName);
                if (System.IO.File.Exists(FullfilePhysicalPath))
                {
                    return File(FullFileLogicalPath, "Application/pdf", FileName);
                }
                else
                {
                    return Json(new { Success = "false" });
                }
    
                return View();
            }
    }
