    using(SqlConnection cn = GetConnection())
    {
        cn.Open();
        SqlTransaction tr = cn.BeginTransaction("myTransaction");
        .....
    
        SqlCommand command = new SqlCommand(sqlString, cn);
    
        // Here the reader use an open connection, so don't try to close on exit from using
        using(SqlDataReader reader = command.ExecuteReader())
        {
            .....
        }
        tr.Commit();
    
    }
