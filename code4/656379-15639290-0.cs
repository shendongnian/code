    using (SqlConnection conn = new SqlConnection(cCon.getConn()))
    using (SqlCommand cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "sp_SaveSomething";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@x", xxx));
        cmd.Parameters.Add(new SqlParameter("@ORG", ORG));        
        cmd.ExecuteNonQuery();
    }
