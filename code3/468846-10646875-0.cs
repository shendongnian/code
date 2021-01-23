    public void DisplyGridview(){
	string connStr = ConfigurationManager.ConnectionStrings["bbsConnectionString"].ConnectionString;
        using (SqlConnection Con = new SqlConnection(connStr))
        {
            SqlDataAdapter sdr = new SqlDataAdapter(str, Con);
            sdr.SelectCommand.Parameters.AddWithValue("@startdate", startdate);
            sdr.SelectCommand.Parameters.AddWithValue("@enddate", enddate);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Button2.Visible = true;
              }
        }
