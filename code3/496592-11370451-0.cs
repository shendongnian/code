    public class EmployeeController : Controller
    {
    	public ActionResult Index()
    	{
    	   var employeeModel = new Employee
    	   {
    		   FirstName = "Hat",
    		   LastName = "Soft",
    		   Departments = new BindingList<SelectListItem>
    			{
    				new SelectListItem {Text = "Accounts", Value = "1"},
    				new SelectListItem {Text = "Human Resource", Value = "2"},
    				new SelectListItem {Text = "Operations", Value = "3"}
    			}
    	   };
    
    		return View(employeeModel);
    	}
    }
