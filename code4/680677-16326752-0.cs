    DataTable topicDt = new DataTable();
    using(SqlConnection con = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand("sp_LoadTopics",con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@subId", _subId);
        con.Open();
        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            da.Fill(topicDt);
        }
    }
    
    return topicDt;
