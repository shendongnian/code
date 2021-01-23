    using Student.Models.Db;
    
    namespace Student.Controllers
    {
        public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
                List<Student> student = null;
                return View();
            }
        }
 
