     public class TestController : Controller
        {
            public ActionResult Index()
            {
                Student student = new Student(10, 20);
                 
                return View();
            }
    
         
        }
