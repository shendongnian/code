    public DataSet Foo(long id)
        {
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlCommand sqlCmd = new SqlCommand("Select * From users where userid=@id", SqlConn);
                    sqlCmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        da.Fill(ds, "Users");
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString);
                return null;
            }
        }
