    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
                //Prepare the model and send it to the view
                Employee emp = new Employee { EmpDepartment = new Department { Name = "IT" } };
                emp.SubOrdinates = new List<Employee> { new Employee { Name = "Emp1" }, new Employee { Name = "Emp2" } };
                return View(emp);
            }
            [HttpPost]
            public ActionResult Index(Employee emp)
            { //Put a break-point here and see how the modified values in view are flowing into emp..
                return View(emp); 
            }
            public ActionResult About()
            {
                return View();
            }
        }
