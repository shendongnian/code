    using(TransactionScope tscope = new TransactionScope())
    {
        using(SqlConnection conn = new SqlConnection(myconnstring)
        {
            conn.Open();
    
            ... Call the necessary stored proc here
    
            tscope.Complete();
            conn.Close();
        }
    }
