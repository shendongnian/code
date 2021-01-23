                    using (var sqlCmd = new SqlCommand("endicia.credentialLookup", sqlConnection))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                        SqlParameter outLogin = new SqlParameter("@login", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                        sqlCmd.Parameters.Add(outLogin);
                        SqlParameter outPassword = new SqlParameter("@password", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                        sqlCmd.Parameters.Add(outPassword);
                        sqlConnection.Open();
                        sqlCmd.ExecuteNonQuery();
                        string login, password;
                        login = outLogin.Value.ToString();
                        password = outPassword.Value.ToString();
                        //using (SqlDataReader rdr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection))
                        //{
                        //    while (rdr.Read())
                        //    {
                        //        int contactID = rdr.GetInt32(rdr.GetOrdinal("ContactID"));
                        //        string firstName = rdr.GetString(rdr.GetOrdinal("FirstName"));
                        //    }
                        //    rdr.Close();
                        //}
                    }
                **}**
