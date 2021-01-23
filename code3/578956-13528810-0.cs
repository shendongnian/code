    public ActionResult SomeAction()
    {
        IList<Student> students = new List<Student>();
        students.Add(new Student { Name = "foo", GuardianName = "bar" });
        return View(students);
    }
