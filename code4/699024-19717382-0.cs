    [HttpPost]
    public ActionResult Add(Applicant applicant)
    {
        repository.SaveApplicant(applicant);
        TempData["message"] = "The applicant has been saved succesfully.";
        return View(applicant);
    }
