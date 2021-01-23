        public class HomeController : Controller
        {
            //
            // GET: /Home/
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost] // requires HttpPost attribute
            public JsonResult SendData(SearchObject payload)
            {
                // do something here
                return Json(new { status = "Success" });
            }
        }
        public class SearchObject
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public List<string> Meals { get; set; }
        }
