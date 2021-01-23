    //production code/project
    public interface IDatabase {
        void addNewProduct(Product product);
    }
    public class SystemUnderTest {
        private IDatabase _database;
        public SystemUnderTest(IDatabase database) {
            _database = database;
        }
        public void DoSomthing(Product product) {
            _database.addNewProduct(product);
        }
    }
    //Unit Test project
    public class MockDatabase : IDatabase {
        public void addNewProduct(Product product)
        { //mock implementation}
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var mock = new MockDatabase();
            var fakeProduct = new Product();
            mock.addNewProduct(fakeProduct );
            var sut = new SystemUnderTest(mock);
            //Act
            sut.DoSomthing(product);
            //Assert
            //Whatever you like to assert
        }
    }
