    public ActionResult ShowStudent(string StudentID)
    {
        var possibleStudents = Enumerable.Range(StudentID.Length, 8 - StudentID.Length).Select(l => StudentID.PadLeft(l, '0'));
        ViewData.Model = student.vwStudent.Where(s => possibleStudents.Contains(s.StudentID));
        return View();
    }
