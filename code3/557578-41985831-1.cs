    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Db = new SqlConnection("MyConnectionString");
    
            // ... initialize data in the test database ...
        }
    
        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    
        public SqlConnection Db { get; private set; }
    }
    
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
    
    [Collection("Database collection")]
    public class DatabaseTestClass1
    {
        DatabaseFixture fixture;
    
        public DatabaseTestClass1(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }
    }
    
    [Collection("Database collection")]
    public class DatabaseTestClass2
    {
        // ...
    }
