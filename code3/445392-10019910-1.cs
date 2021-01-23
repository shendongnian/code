    public static SqlConnection sqlConnectOneTime(string varSqlConnectionDetails) {
        var sqlConnection = new SqlConnection(varSqlConnectionDetails);
        try {
            sqlConnection.Open();
        } catch {
            //log and
            sqlConnection.Close();
            throw
        }
        return sqlConnection;
    }
