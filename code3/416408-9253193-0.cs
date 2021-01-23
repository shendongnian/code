    public TResult UsingSqlConnection<TResult>(Func<SqlConnection, TResult> myFunc)
    {
        using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
        {
            sqlConn.Open();
            return myFunc(sqlConn);
        }
    }
    
    public MyEntity Read(int id)
    {
        return UsingSqlConnection((sqlConn) => MyDataLayer.Read(sqlConn, id));       
    }
