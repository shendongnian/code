    public ActionResult Index(string jobType)
    {
        if (jobType.ToLower() == "this")
            return RedirectToAction("CandidateResults");
        else
            return RedirectToAction("JobResults");
        
        return null; //Code is unreachable
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
