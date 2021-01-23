    using (SqlConnection conn = new SqlConnection(cCon.getConn()))
    {
        using (SqlCommand cmd = new SqlCommand("sp_SaveSomething", conn))
        {
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@x", xxx));
            cmd.Parameters.Add(new SqlParameter("@ORG", ORG));        
            cmd.ExecuteNonQuery();
        }
    }
