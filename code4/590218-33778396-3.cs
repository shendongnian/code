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
