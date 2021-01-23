    public ActionResult Index(string jobType)
    {
        if (jobType.ToLower() == "this")
            return CandidateResults();
        else
            return JobResults();
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
