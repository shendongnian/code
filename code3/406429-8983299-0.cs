    public class HomeController: Controller
    {
        ...
    
        public ActionResult CreateCustomerList()
        {
            SchoolInDB db = new SchoolIn.Models.SchoolInDB();
            var courseprogresses = db
                .CourseProgresses
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .ToList();
            return View(courseprogresses);
        }
    }
