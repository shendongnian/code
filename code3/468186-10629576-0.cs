    public ActionResult IssueList(string projectName) // projectName may be null
    {
        var issueListModel = new IssueListModel();
        issueListModel.Issues = SomeRepository.GetIssues(projectName); // whatever you need to send...
        return View(issueListModel);
    }
