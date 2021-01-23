            try
            {
                using (var conn = new SqlConnection("Server =(local); Database = Database1; Integrated Security = SSPI"))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("getName", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter("@id", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = id;
                        cmd.Parameters.Add(param);
                        var oResult = cmd.ExecuteScalar();
                        if ((oResult != null) && (oResult != DBNull.Value))
                        {
                            name = (string)oResult;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            { 
                //  Do something with the exception here, don't just ignore it
            }
