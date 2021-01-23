    public DataTable SelectAllItems(string itemCode)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(Connection.getConnection()))
        using (SqlCommand cmd = new SqlCommand("selectAllItems", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemCode", itemCode);
            conn.Open();
    
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
    
        }
        return dt;
    }
