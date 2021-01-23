    public ActionResult ShowStudent(string StudentID)
    {
        var padded = StudentID.PadLeft(8, '0');
        ViewData.Model = student.vwStudent.Where(s => s.StudentID == padded);
        return View();
    }
