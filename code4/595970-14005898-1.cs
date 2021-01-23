    using(SqlConnection con = new SqlConnection())
    {
      con.ConnectionString = "server=(local);database=PhilipsMaterials;Integrated Security=SSPI;";
      con.Open();
      DataSet ds = new DataSet();
      DataTable dt = new DataTable();
      string sql = "Select * from Materials";
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds);
      dt = ds.Tables[0];
      DataRow[] drowpar = dt.Select();
    
      StringBuilder sbRenderOnMe = new StringBuilder();
      foreach (DataRow dr in drowpar)
      {
         sbRenderOnMe.AppendFormat("Some Menu Names : {0}", dr["Material Name"]);
      }
      con.Close();
    }
    
    txtInfo.Text = sbRenderOnMe.ToString();
