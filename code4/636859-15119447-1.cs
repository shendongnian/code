            string english_w = string.Empty;
            using (SqlConnection mssql_con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Imon-Bayazid\Documents\ovhidhan_e_word.mdf;MultipleActiveResultSets=true;Integrated Security=True;Connect Timeout=30;User Instance=True"))
            {
                using (SqlCommand mssql_cmnd = new SqlCommand("SELECT * from Table1", mssql_con))
                {
                    mssql_con.Open();
                    using (SqlDataReader rd = mssql_cmnd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            english_w = rd.GetString(0);
                            using (SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Imon-Bayazid\Documents\ovidhan.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"))
                            {
                                con2.Open();
                                using (SqlCommand cmnd2 = new SqlCommand("select top 1 from dic where english=@h", con2))
                                {
                                    cmnd2.Parameters.AddWithValue("@h", english_w);
                                    object obj = cmnd2.ExecuteScalar();
                                    if (obj == null)
                                    {
                                        using (SqlCommand c = new SqlCommand("insert into dic values(@k)", con2))
                                        {
                                            c.Parameters.AddWithValue("@k", english_w);
                                            c.ExecuteNonQuery();
                                        }
                                    }
                                }
                                con2.Close();
                            }
                        }
                        rd.Close();
                    }
                }
                mssql_con.Close();
            }
