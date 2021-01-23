     using (SqlConnection con = new SqlConnection(ConnectionString)) //for connecting to database
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand getchild = new SqlCommand("select count(*) from table1 ", con)) //SQL queries
                        {
                            Int32 count = (Int32)getchild.ExecuteScalar();
                         }
                    }
                 }
