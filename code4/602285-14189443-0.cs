    static int ReturnIDfromDb(string sqlString, string outputParam) {
        string connectionString = ConfigurationManager.ConnectionStrings["xxx"].ConnectionString;
        using(DbConnection conn = new SqlConnection(connectionString))
        using(DbCommand comm = conn.CreateCommand()) {
            comm.CommandText = sqlString;
            ...
        }
    }
