            string sqltext = @"select a.columnown, a.columntwo, a.columnthreee from blahblah as a";
            List<List<string>> toReturn = new List<List<string>>();
            using (SqlConnection con = new SqlConnection("YourConnectionString"))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sqlTest;
                using (SqlDataReader sqlReader = cmd.ExecuteReader())
                {
                    if (sqlReader != null)
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                List<string> innerList = new List<string>();
                                for (int i = 0; i < sqlReader.FieldCount; i++)
                                {
                                    innerList.Add(sqlReader[i].ToString());
                                }
                                toReturn.Add(innerList);
                            }
                            con.Close();
                        }
                    }
                }
            }
