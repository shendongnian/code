    private MyFile getDownload(string sql)
    {
        SqlDataReader dr;
        using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
        {
            SqlCommand cmd = new SqlCommand("getInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = sql;
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
        
    
            return new MyFile {
                      file_name = dr["mfile_name],
                      file_data = dr["file_data]
            }
        }
    }
