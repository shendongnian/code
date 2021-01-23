    public DataTable GetData(int par1, int? par2)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                string sql = "StoredProcedure_name";
                da.SelectCommand = new SqlCommand(sql, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Par1", SqlDbType.Int).Value = par1;
                da.SelectCommand.Parameters.Add("@Par2", SqlDbType.Int).Value = (object)par2?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds, "SourceTable_Name");
        
                DataTable dt = ds.Tables["SourceTable_Name"];
        
                //foreach (DataRow row in dt.Rows)
                //{
                //You can even manipulate your data here
                //}
                return dt;
            }
        }
    }
