        public class UploadController : Controller
        {
            //
            // GET: /Upload/
    
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Index(IEnumerable<HttpPostedFileBase> fileUpload)
            {
    
                return View();
            }
    
        }
    
