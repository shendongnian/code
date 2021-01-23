    public class NewsFeedController : Controller
    {
         public ActionResult Index()
         {
              var modelData = _db.NewsItems.OrderByDescending(...);
              // Hook up or initialize _db here however you normally are doing it
              return PartialView(modelData);
         }
    }
