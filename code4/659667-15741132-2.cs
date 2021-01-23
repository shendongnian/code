    public sealed class HomeController : Controller
    {
        public ActionResult Index(string department, EmployeeType employeeType)
        {
            /* ... */
        }
    }
    public enum EmployeeType
    {
        FullTime,
        PartTime,
    }
