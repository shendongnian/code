    public ActionResult ProjectDetail(string projectName)
    {
        var projectDetailModel = new ProjectDetailModel();
        projectDetailModel.Issues = SomeRepository.GetIssues(projectName, 10); // whatever you need to send
        return View(projectDetailModel);
    }
