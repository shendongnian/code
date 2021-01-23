    public class EmployeesController : Controller
    {
        public ActionResult Edit(int id)
        {
             var model = GetEmployee(id); // replace with your actual data access logic
    
             return View(model);
        }
    }
