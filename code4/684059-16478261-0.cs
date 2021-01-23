    public Variables Find(string name)
            {
                var objVariable = new Variables();
    
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringValue"].ToString()))
                {
                    conn.Open();
    
                    var sql = @" select top 1 * 
                                from SomeTable 
                                where Column1 = @Name";
    
                    try
                    {
                        var cmd = new SqlCommand(sql, conn);
                        cmd.CommandType = CommandType.Text;
    
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
    
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                objVariable.Column1 = dr["Column1"].ToString();
                                objVariable.Column2 = dr["Column2"].ToString();
                            }
                        }
    
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
    
                return objVariable;
    
            }
