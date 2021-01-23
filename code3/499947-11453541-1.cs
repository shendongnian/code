    using(SqlConnection cn = GetConnection())
    {
        cn.Open();
        SqlTransaction tr = cn.BeginTransaction("myTransaction");
        .....
    
        SqlCommand command = new SqlCommand(sqlString, cn);
    
        using(SqlDataReader reader = command.ExecuteReader())
        {
            .....
        }
        tr.Commit();
    }
