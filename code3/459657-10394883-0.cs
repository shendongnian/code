    // "RegularProcessing" in test name feels a bit forced;
    // in such cases, you can simply skip 'conditions' part of test name
    public void ProjectsPresenter_SetsViewProjectsCorrectly()
    {
        var view = MockRepository.GenerateMock<IProjectView>();
        var repository = MockRepository.GenerateMock<IProjectsRepository>();
        // Don't even need content;
        // reference comparison will be enough
        List<Project> projects = new List<Project>();
        // We use repository in stub mode;
        // it will simply provide data and that's all
        repository.Stub(r => r.FetchAll()).Return(projects);
        ProjectsPresenter presenter = new ProjectsPresenter(repository, view);
        // In assert part we do state-based verification;
        // we check if view.projects is the same collection as returned by repository
        Assert.That(view.projects, Is.EqualTo(projects));
    }
