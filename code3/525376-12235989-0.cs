    public class SqLiteConnectionFactory : IDbConnectionFactory
    {
         public System.Data.Common.DbConnection CreateConnection(string nameOrConnectionString)
         {
           var databaseDirectory = @"C:\\master.db";
    
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = databaseDirectory,
                Version = 3
            };
            return new SQLiteConnection(builder.ToString());
           }
    }
