    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
    builder["Initial Catalog"] = "Server";
    builder["Data Source"] = "db";
    builder["integrated Security"] = true;
    string connexionString = builder.ConnectionString;
    SqlConnection connexion = new SqlConnection(connexionString);
    try { connexion.Open(); return true; }
    catch { return false; }
