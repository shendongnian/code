        using (SqlConnection conn = new SqlConnection(cCon.getConn()))
        using (SqlCommand cmd = new SqlCommand("sp_SaveSomething", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@x", xxx));
            cmd.Parameters.Add(new SqlParameter("@ORG", ORG));
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log error, etc.
            }
        }
