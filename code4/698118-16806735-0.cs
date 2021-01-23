    Public DataTable PopulateCombo(string NoTypeRoom,string IDBranch)
    {
    SqlCommand cmd = new SqlCommand("viewRoom", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@NoTypeRoom", NoTypeRoom);
    cmd.Parameters.AddWithValue("@IDBranch", IDBranch);
    SqlDataAdapter dap = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    dap.Fill(ds);
    return ds.Tables[0];  
    }
