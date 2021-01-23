    public ActionResult RemoveStudent(int id)
    {
        StudentDataContext student= new StudentDataContext();
        var std = student.Students.Single(s => s.StudentID == id);
        student.Students.DeleteOnSubmit(std);
        student.SubmitChanges();
        ViewData["Message"] = "Student " + std.StudentId.ToString() + " Removed";
        return View();
    }
