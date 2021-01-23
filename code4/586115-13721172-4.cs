    using (SqlConnection conn = new SqlConnection(...))
    {
        conn.FireInfoMessageEventOnUserErrors = true;
        conn.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
        using (SqlCommand comm = new SqlCommand("dbo.sp1", conn) 
               { CommandType = CommandType.StoredProcedure })
        {
            conn.Open(); 
            comm.ExecuteNonQuery();
        }
    }
    static void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        // Process received message
    }
