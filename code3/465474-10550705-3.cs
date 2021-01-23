    System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder();
    
    builder.ConnectionString = connectionString;
    
    string server = builder["Data Source"] as string;
    string database = builder["Database"] as string;
