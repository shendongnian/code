    public class EmployeeController : Controller
    {
        private EmployeeContext _context;
     
        public EmployeeController()
        {
            _context = new EmployeeContext();
        }
            
        public ActionResult Index()
        {
            return View(_context.Employees.ToList());
        }
            
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
