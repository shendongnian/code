    using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from tblUser"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            var result = (from row in dr.DataRecord()
                                          select new
                                             {
                                                 UserId = row[0],
                                                 UserName = row[1]
                                             }).ToList();                        
                        }
                    }
                }
