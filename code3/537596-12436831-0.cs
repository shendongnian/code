    SqlConnection con = new SqlConnection("<< connection string >>");
    cmd = new SqlCommand("SELECT UserId, Date, Report FROM Daily_Report WHERE Date=@Date or UserId=@UserId", con);
    cmd.Parameters.AddWithValue("@Date", txtdate.Text);
    cmd.Parameters.AddWithValue("@UserId", txtempid.Text);
    con.Open();
    SqlDataReader rdr = cmd.ExecuteReader();
    GridView2.DataSource = rdr;
    GridView2.DataBind();
    
    con.Close();
