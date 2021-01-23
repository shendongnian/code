    finally
    {
        if (sqlconn != null)
        {
            if (sqlConn.ConnectionState == ConnectionState.Open) sqlconn.Close();
            sqlConn.Dispose();
            GC.SuppressFinalize(sqlConn);
            sqlConn = null;
        }
    }
