    public class UnsecureDealsController : Controller
    {
        public ActionResult View()
        {
            return View();
        }
    }
    
    public class SecureDealsController : Controller
    {
        [HttpPost]
        [Authorize]
        public ActionResult Add(DealViewModel newDeal)
        {
            // Code to add the deal to the db
        }
        public ActionResult View()
        {
            return RedirectToAction("View", "UnsecureDeals");
        }
    }
