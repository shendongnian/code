                using (SqlConnection con = Connection.GetConnection())
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT count(UserName) FROM" + tblName +
                        " WHERE Password=@pPass AND usertype=@pUsertype AND
                        username=@pUsername";
                        cmd.Parameters.Add("@pUsername", SqlDbType.VarChar);
                        cmd.Parameters.Add("@pPass", SqlDbType.VarChar);
                        cmd.Parameters.Add("@pUsertype", SqlDbType.VarChar);
                        cmd.Parameters["pUsername"] = UserName;
                        cmd.Parameters["pPass"] = Password;
                        cmd.Parameters["pUsertype"] = Usertype;
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            return true;
                        return false;
                    }
                }
