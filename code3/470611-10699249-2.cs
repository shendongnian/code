     using (SqlConnection con = new SqlConnection(ConnectionString)) //for connecting to database
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand getchild = new SqlCommand("select count(*) from table1 ", con)) //SQL queries
                        {
                            SqlDataReader reader = getchild.ExecuteReader(); //executing the queries
                            String str = reader.GetString(0);
                         }
                    }
                 }
