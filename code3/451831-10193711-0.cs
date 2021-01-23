    using(SqlConnection conn = new SqlConnection(connString))
    {
        try
        {
            conn.Open();
            // do more stuff here......
       
        }
        catch(SqlException sqlEx)
        {
           // log error and possibly show to user in a MessageBox or something else
        }
    }
