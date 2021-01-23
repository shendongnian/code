    public static SqlConnection GetConnection()
    {
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        builder["Initial Catalog"] = "Upload";
        builder["Data Source"] = "base";
        builder["integrated Security"] = true;
        string connexionString = builder.ConnectionString;
        connexion = new SqlConnection(connexionString);
        return connexion; 
    }
