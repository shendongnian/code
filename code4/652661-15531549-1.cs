    public class HomeController : Controller
    {
        private readonly SoapWebService _db;
    
        public HomeController()
            : this(new SoapWebService())
        {
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
