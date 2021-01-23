    public class SomeRepositoryTests
    {
        private DbContext _context;
        [SetUp]
        public void Setup()
        {
            Database.SetInitializer(new TestDatabaseInitilizer());
            _context = new DbContext("TestContext");
            _repository = new SomeRepository(_context);
        }
        [Test]
        public void should_return_some_entities()
        {
            Assert.That(_repository.Get(), Is.Not.Null);
        }
    }
