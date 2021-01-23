    public ActionResult ShowStudent(long studentId)
    {
        var studentIdStr = studentId.ToString( "D9" );  // 9-digit number, padded w/ zeros
        ViewData.Model = student.vwStudent.Where(s => s.StudentId == studentIdStr);
        return View();
    }
