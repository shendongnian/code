    [TestFixture]
    public void SomeTest : WithDatabaseContext
    {
        private IFixture fixture;
    
        [SetUp]
        public void Init()
        {
            this.fixture = new Fixture();
            this.fixture.Register(
                () => new ProjectRepository(base.DataContextFactory));
        }
    
        [Test]
        public void Doing_something_should_return_something_else()
        {
            // ...
        }
    }
