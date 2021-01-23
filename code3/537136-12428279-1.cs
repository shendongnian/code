    [TestFixture]
    class ProjectDataServiceTest
    {
        private ProjectDataService _projectDataService;
        private DatabaseSeeder _seeder;
        private SiteContext _context;
    
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
    
            _context = new SiteContext(); // connection string is taken from app.config file
    
            _seeder = new DatabaseSeeder(_context);
            _seeder.InitialiseDb();  // create database structure
    
            ProjectRepository projectRepository = new ProjectRepository(_context);
    
            _projectDataService = new ProjectDataService(projectRepository);
    
        }
    
        [SetUp]
        public void TestSetUp()
        {
            _seeder.SeedDatabase(); // put some test data from a script
        }
    
        [TearDown]
        public void TestTearDown()
        {
            _seeder.RemoveData(); // delete everything from all the tables
        }
    
        /**************** Tests are here! ********************/
    
        [Test]
        public void CheckDatabaseConnectivity()
        {
            Assert.Pass();
        }
    
        [Test]
        public void GetNoProjectsForUser()
        {   // should return no project for this user, as nothing is assigned
            var user = _seeder.Users[0];
            var projects = _projectDataService.GetUserProjects(user);
    
            Assert.IsEmpty(user.UserProjectRoles);
            Assert.IsEmpty(projects);
        }
    
        [Test]
        public void GetAllProjetsForUser()
        {
            var user = _seeder.Users[2];
            var projects = (List<Project>)_projectDataService.GetUserProjects(user);
            int count = user.UserProjectRoles.Count;
    
            Assert.AreEqual(count, projects.Count);
    
            Assert.False(projects.Contains(_seeder.Projects[0]));
        }
     }
