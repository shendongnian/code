      using (...)
      {
        SqlCommand cmd       = new SqlCommand("dbo.InsertStoreAndDistricts", connectionObject);
        cmd.CommandType      = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@Districts", Districts);
        // other params here - name and image
        tvparam.SqlDbType    = SqlDbType.Structured;
        cmd.ExecuteNonQuery();
      }
