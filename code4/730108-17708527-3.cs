    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public JsonResult GetDropDownValues(int? type)
        {
            var values = new List<string>();
            switch (type)
            {
                case 1:
                    values = Enumerable.Range(1, 10).Select(n => n.ToString()).ToList();
                    break;
                case 2:
                    values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(c => c.ToString()).ToList();
                    break;
            }
    
            return Json(new SelectList(values));
        }
    }
