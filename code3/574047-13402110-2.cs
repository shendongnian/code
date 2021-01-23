    //Your code to this point
    DataTable dt = new DataTable();
    using(var cmd = new SqlCommand("usp_GetABCD", sqlcon))
    {
      using(var da = new SqlDataAdapter(cmd))
      {
          da.Fill(dt):
      }
    }
