    public ActionResult Bar(FirstStepViewModel firstStep)
    {
        var model = new SecondStepViewModel
        {
            ProjectName = firstStep.ProjectName
        };
        return View(model);
    }
