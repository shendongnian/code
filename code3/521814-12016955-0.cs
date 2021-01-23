    public class HomeController : Controller
    {
        // Serve the view initially
        public ActionResult Index()
        {
            return View();
        }
        // This will be called using AJAX and return an XML document to the
        // client that will be manipulated using javascript
        public ActionResult GetXml()
        {
            return Content("<foo><bar id=\"1\">the bar</bar></foo>", "text/xml");
        }
        // This will be called using AJAX and passed the new XML to persist
        [HttpPost]
        public ActionResult Save(XDocument xml)
        {
            // TODO: save the XML or something
            return Json(new { success = true });
        }
    }
