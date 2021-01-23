    var entityConnectionStringBuilder= new EntityConnectionStringBuilder();
    entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
    entityConnectionStringBuilder.ProviderConnectionString = <your SQL Server connection string>;
    entityConnectionStringBuilder.Metadata = "res://*";
    MyClassDBContext a = new MyClassDBContext(entityConnectionStringBuilder.ToString());
