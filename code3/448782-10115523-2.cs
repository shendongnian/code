    public ActionResult ShowStudent(string StudentID)
    {
     var x = student.vwStudent.Where(s => s.StudentID == StudentID).FirstOrDefault();
     while( x != null && StudentID.Length < 15)
     {
      StudentID = "0" + StudentID;
      x = student.vwStudent.Where(s => s.StudentID == StudentID).FirstOrDefault();
     }
     ViewData.Model = x;
     return View();
    }
