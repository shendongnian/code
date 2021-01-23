      using (...)
      {
        SqlCommand cmd       = new SqlCommand("dbo.InsertStoreAndDistricts", sqlConnection);
        cmd.CommandType      = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@Districts", Districts);
        tvparam.SqlDbType    = SqlDbType.Structured;
        // other params here - name and image
        cmd.ExecuteNonQuery();
      }
