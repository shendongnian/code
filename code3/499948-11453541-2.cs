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
        SqlCommand command1 = new SqlCommand(sqlString1, cn);
        using(SqlDataReader reader1 = command1.ExecuteReader())
        {
            .....
        }
        tr.Commit();
    }
