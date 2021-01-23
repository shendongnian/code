    public static class Extension
    {
        public static void TestConnection(this DbConnection connection)
        {
            var builder = new DbConnectionStringBuilder
                {
                    ConnectionString = connection.ConnectionString
                };
        }
    }
