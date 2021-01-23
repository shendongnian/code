    public class HomeController : Controller
    {
        private readonly SoapWebService _db;
    
        public HomeController()
        {
            _db = new SoapWebService();
        }
    
        public HomeController(SoapWebService db)
        {
            _db = db;
        }
    
        public ActionResult Index()
        {
            return View(_db.GetAllItems("APIKey").ToList());
        }
     }
