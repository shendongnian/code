    public class TestController : Controller
    {
        private BookingSystemEntities db = new BookingSystemEntities();
        public ActionResult Index()
        {
            var user = db.Users.Single(u => u.Email == User.Identity.Name);
            var appointments = db.Appointments.Where(a => a.User.CompanyID == user.CompanyID).AsEnumerable();
            return View(appointments);
        }
    
        public override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
