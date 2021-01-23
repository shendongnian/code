     public class TestController : Controller
        {
            public ActionResult Index()
            {
                Student student = new Student(10, 20);
                 
                return View(student);
            }
            public ActionResult UpdateStudent(Student student)
            {
                //access the DB here
                 
                return View("Index",student);
            }
    
         
        }
