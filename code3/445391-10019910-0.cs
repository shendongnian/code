    public SqlConnection sqlConnectOneTime(string varSqlConnectionDetails) {
        var sqlConnection = new SqlConnection(varSqlConnectionDetails);
        try {
            sqlConnection.Open();
        } catch {
            //log and
            throw
        }finally{
            sqlConnection.Close();
        }
        return sqlConnection;
    }
