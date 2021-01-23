    public ActionResult Index()
            {
                List<vwStudent> students = new List<vwStudent>();
                students.Add(new vwStudent() { PastDueAmount = 100, PastDueDays = "None", StudentID = "ooooo" });
                students.Add(new vwStudent() { PastDueAmount = 102, PastDueDays = "No", StudentID = "Sollina" });
                return View(students);
    
            }
            [HttpPost]
            public ActionResult Index(List<vwStudent> studentModel)
            {
               
                return View(studentModel);
    
            }
