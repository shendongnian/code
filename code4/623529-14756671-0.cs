    [HttpGet]
    public ActionResult ProfileAccount(int id)
    {
        // Get whatever info you need and store in a ViewModel
        var model = new ProfileAccountView();
        // Get the student info and store within ProfileAccountView
        // Do your database reads
        model.StudentName = new StudentNameModel { StudentName = result };
        return View(model);
    }
    [HttpPost]
    public ActionResult ProfileAccount(ProfileAccountView profile)
    {
        // Do whatever processing here
    }
