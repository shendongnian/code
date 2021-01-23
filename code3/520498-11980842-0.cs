    using(TransactionScope ts = new TransactionScope())
    {
        
            using(SqlConnection conn = new SqlConnection(myconnstring)
            {
                conn.Open();
        //call first executenonquery
        //call second executenonquery
                ts.Complete();
                conn.Close();
            }
    }
