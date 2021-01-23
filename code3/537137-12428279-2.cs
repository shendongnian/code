        [TestFixture]
        class ProjectsControllerTest
        {
            private ProjectsController _projectController;
    
            private Mock<IProjectDataService> _projectDataService;
            private Mock<ICurrentUserService> _currentUserService;
    
            [SetUp]
            public void SetUp()
            {
                MapperConfig.SetMappings();
                
                _projectDataService = new Mock<IProjectDataService>();
                _currentUserService = new Mock<ICurrentUserService>();
    
                _currentUserService.Setup(s => s.GetCurrentAppUser()).Returns(new AppUser());
    
                _projectController = new ProjectsController(_projectDataService.Object, _currentUserService.Object);
            }
            
            
            [Test]
            public void InstanceOfProjectController()
            {
                Assert.IsInstanceOf<ProjectsController>(_projectController);
            }
    
    
            [Test]
            public void Index()
            {
                var projects = new List<Project>() { new Project() { Name = "one" }, new Project() { Name = "two" } };
    
                _projectDataService.Setup(s => s.GetUserProjects(It.IsAny<AppUser>())).Returns(projects);
    
                var view = _projectController.Index();
    
                Assert.IsInstanceOf<AutoMapViewResult<List<ProjectViewModel>>>(view);
            }
    }
