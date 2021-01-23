    [HttpPost]
    public ViewResult StepTwo(JobApplicationViewModel viewModel)
    {
        ServiceLayer.Update(viewModel);
        return View(viewModel);
    }
