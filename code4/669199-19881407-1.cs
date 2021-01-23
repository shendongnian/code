    public class HomeController : Controller
        {
            myEntity db = new myEntity();
    
            public ActionResult Index()
            {
                return View(db.myTable.ToList());
            }
    }
