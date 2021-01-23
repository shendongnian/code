    public ActionResult Index(string jobType)
        {
            if (jobType.ToLower() == "this")
                return RedirectToAction("CandidateResults","ControllerName");
            else
                return RedirectToAction("JobResults","ControllerName");
        }
