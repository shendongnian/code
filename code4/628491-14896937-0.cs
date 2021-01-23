    public ActionResult Index(string jobType)
    {
        return (jobType.ToLower() == "this") ?
            RedirectToAction("CandidateResults") :
            RedirectToAction("JobResults");
    }
    private ActionResult CandidateResults()
    {
        var model = //logic
        return View(model);
    }
    private ActionResult JobResults()
    {
        var model = //logic
        return View(model);
    }
