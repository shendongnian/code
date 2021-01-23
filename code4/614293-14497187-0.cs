    public ActionResult ParentsDetails()
    {
        var studentDetails = new List<StudentDetail>();
        var parentDetails = new List<ParentsDetail>();
        // Fill your lists here, and pass them to viewmodel constructor.
        var viewModel = new ParentsInformationViewModel(studentDetails, parentDetails)
        // Return your viewmodel to corresponding view.
        return View(viewModel);
    }
