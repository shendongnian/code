    public static void TestConnection(this DbConnection connection)
        {
            var builder = new DbConnectionStringBuilder
                {
                    // throw ArgumentException if not correct format
                    ConnectionString = connection.ConnectionString 
                };
        }
