    public ActionResult Index(string jobType)
    {
        if (jobType.ToLower() == "this")
            CandidateResults();
        else
            JobResults();
    }
    private ActionResult CandidateResults()
    {
        var model = //logic
        return View("CandidateResults", model);
    }
    private ActionResult JobResults()
    {
        var model = //logic
        return View("JobResults", model);
    }
