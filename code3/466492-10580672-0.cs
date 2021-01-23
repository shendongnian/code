    public ActionResult Index()
    {
        var studentList = db.Students.ToList();
        return View(new ModelView { students = studentList });
    }
