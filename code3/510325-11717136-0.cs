    var connectionString = System.Configuration.ConfigurationManager.
        ConnectionStrings["connectionStringName"].ConnectionString;
    var builder = new System.Data.Common.DbConnectionStringBuilder();
    builder.ConnectionString = connectionString;
    var internalConnectionString = builder["provider connection string"].ToString();
    var newConnectionString = internalConnectionString.Replace("oldDBName", "newDBName");
    builder["provider connection string"] = newConnectionString;
    var entitiesContext = new NerdDinnerEntities(builder.ConnectionString);
