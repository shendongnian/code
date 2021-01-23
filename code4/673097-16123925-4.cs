    [TestClass]
    public class DataRepositoryTests
    {
        private IRepository<DataRepositoryIntegrationTest> _repo;
        private static DataContext _context;
        [ClassCleanup]
        public static void CleanUp()
        {
            _context.Dispose();
        }
        public DataRepositoryTests()
        {
            _context = new DataContext(Settings.Default.IntegrationTestConnectionString);
        }
        [TestInitialize]
        public void InitRepository()
        {
            _context.ExecuteCommand("truncate table dbo.PrefExtensions_IntegrationTest");
            _context.ExecuteCommand("insert into dbo.PrefExtensions_IntegrationTest ([Value], [DateInserted]) values ('Test1', getdate())");
            _context.ExecuteCommand("insert into dbo.PrefExtensions_IntegrationTest ([Value], [DateInserted]) values ('Test2', getdate())");
            _context.ExecuteCommand("insert into dbo.PrefExtensions_IntegrationTest ([Value], [DateInserted]) values ('Test3', getdate())");
            _repo = new TestRepository(_context);
        }
        private DataRepositoryIntegrationTest CreateItem(string value)
        {
            return new DataRepositoryIntegrationTest { Value = value, DateInserted = DateTime.Now };
        }
        [TestMethod]
        public void ShouldInsertItem()
        {
            // arrange
            var item = CreateItem("Test.ShouldInsert1");
            var expectedCount = _repo.Count + 1;
            // act
            _repo.Save(item);
            var actualCount = _repo.Count;
            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void ShouldInsertItems()
        {
            // arrange
            var count = _repo.Count;
            var items = new DataRepositoryIntegrationTest[] { 
                CreateItem("Test.ShouldInsert1"),
                CreateItem("Test.ShouldInsert2")};
            var expected = count + items.Length;
            // act
            _repo.Save(items);
            var actual = _repo.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldUpdateItem()
        {
            if (_repo.Count == 0) throw new AssertInconclusiveException("ShouldUpdateItem requires an existing item.");
            // arrange
            var item = _repo.Item(new DataRepositoryIntegrationTest { Id = 1 });
            var expected = "updated";
            item.Value = expected;
            // act
            _repo.Save(item);
            var result = _repo.Item(new DataRepositoryIntegrationTest { Id = item.Id });
            var actual = result.Value;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldDeleteItem()
        {
            if (_repo.Count == 0) throw new AssertInconclusiveException("ShouldUpdateItem requires an existing item.");
            // arrange
            var item = _repo.Item(new DataRepositoryIntegrationTest { Id = 1 });
            var expected = _repo.Count - 1;
            // act
            _repo.Delete(item);
            var actual = _repo.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldDeleteItems()
        {
            if (_repo.Count < 2) throw new AssertInconclusiveException("ShouldUpdateItem requires 2 existing items.");
            // arrange
            var items = new DataRepositoryIntegrationTest[] {
                new DataRepositoryIntegrationTest { Id = 1 },
                new DataRepositoryIntegrationTest { Id = 2 }};
            var expected = _repo.Count - items.Count();
            // act
            _repo.Delete(items);
            var actual = _repo.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
