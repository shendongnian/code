    public ActionResult CreateJob(CreateJobModel viewModel)
    {
        var call = FindCall(viewModel.CallNumber);
    
        if (call == null)
        {
            ModelState.AddModelError(nameof(CreateJobModel.CallNumber), "Idiot User!");
        }
    }
