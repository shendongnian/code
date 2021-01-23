      var sConnection = ((SqlConnection)DbContext.Database.Connection);
        
        DataTable dt = new DataTable();
                    if (sConnection != null && sConnection.State == ConnectionState.Closed)
                    {
                       
                            sConnection.Open();
        		    }
    using(SqlDataAdapter ad = new SqlDataAdapter())
                        {
                        SqlDataAdapter com = new SqlDataAdapter("Select * from Table", sConnection);
                        com.Fill(dt);
                        }
