    public ActionResult ShowStudent(string StudentID)
    {
     while( StudentID.Length < 8 )
     {
      StudentID = "0" + StudentID;
     }
     ViewData.Model = student.vwStudent.Where(s => s.StudentID == StudentID);
     return View();
    }
