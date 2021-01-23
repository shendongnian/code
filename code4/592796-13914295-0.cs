    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
    
    public ActionResult Home(int id)
    {
        Employee model = // Get employee by id
        return View(model);
    }
