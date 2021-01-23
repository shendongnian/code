    public class StudentController : Controller
    {
        //
        // GET: /Student/
    
        public ActionResult Index()
        {
            var studentList = new List<Student>
                                  {
                                      new Student {StudentID = 1, StudentName = "StudentName1"},
                                      new Student {StudentID = 2, StudentName = "StudentName2"},
                                      new Student {StudentID = 3, StudentName = "StudentName3"},
                                      new Student {StudentID = 4, StudentName = "StudentName4"}
                                  };
    
            ViewBag.students = new SelectList(studentList, "StudentID", "StudentName");
            return View();
        } 
    
        [HttpPost]
        public ActionResult Save(String[] students)
        {
            return View();
        }
    
    }
    
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
