    public ActionResult RemoveStudent(int id)
    {
        StudentDataContext student= new StudentDataContext();
        var std = student.Students.Single(s => s.StudentID == id);
        student.Students.DeleteOnSubmit(std);
        student.SubmitChanges();
        ViewBag.Message = "Student " + std.StudentId.ToString() + " Removed";
        return View();
        // or if you want to specify a view name:
        // return View("MyView");
       
        // and if you need to pass a model that the view expects
        // return View("MyView", someModel);
    }
