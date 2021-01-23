    public void ProjectsPresenter_AttachesPresenterToView()
    {
        // Arrange
        var view = MockRepository.GenerateMock<IProjectView>();
        view.Expect(v => v.AttachPresenter(Arg<IProjectsViewObserver>.Is.Anything));
        var repository = MockRepository.GenerateMock<IProjectsRepository>();
        
        // Act
        var presenter = new ProjectsPresenter(repository, view);
        // Assert
        view.VerifyAllExpectations();
    }
