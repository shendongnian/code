    public class Home1Controller : Controller 
    {
        [HttpPost]
        public ActionResult CheckBox(string date)
        {
            return RedirectToAction("ActionName", "Home2", new { Date =date });
        }
    }
