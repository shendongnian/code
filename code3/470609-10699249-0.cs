    using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand getchild = new SqlCommand("select count(*) from table1 ", con))
                    {
                        SqlDataReader reader = getchild.ExecuteReader();
                        
                        
                            String str = reader.GetString(0);
                     }
                }
             }
