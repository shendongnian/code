    public class MyEntities : NerdDinnerEntities
    {
      public MyEntities() : base(GetConnectionString())
      {
      }
    
      private string GetConnectionString()
      {
        var connectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["connectionStringName"].ConnectionString;
        var builder = new System.Data.Common.DbConnectionStringBuilder();
        builder.ConnectionString = connectionString;
        var internalConnectionString = builder["provider connection string"].ToString();
        var newConnectionString = internalConnectionString.Replace("oldDBName", "newDBName");
        builder["provider connection string"] = newConnectionString;
        return builder.ConnectionString;
      }
    }
