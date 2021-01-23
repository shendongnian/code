    public class HomeController {
        public ActionResult Dynamic(string title) {
             // All requests not matching an existing url will land here.
             var page = _database.GetPageByTitle(title);
             return View(page);
        }
    }
