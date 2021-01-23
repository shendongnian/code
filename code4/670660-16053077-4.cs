    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.NGon.Appointments= new[,] { { "4/1/2013", "B'day" }, { "4/2/2013", "Appointment with abc" } };
            return View();
        }
    }
