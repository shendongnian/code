    public class Download
    {
         public string Name { get; set; }
         public byte[] Data { get; set; }
    }
    ...
    private Download getDownload(string sql)
    {
        using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
        using (SqlCommand cmd = new SqlCommand("getInfo", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = sql;
            con.Open();
            Using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    return new Download
                    {
                        Name = (string)dr["mfile_name"],
                        Data = (byte[])dr["file_data"]
                    };
                }
            }
        }
    }
    
    
