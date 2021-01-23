    //SQL Connection stuff here
    con.Open();
    String queryStr = "SELECT name FROM bbc WHERE name like '*%'";
    SqlCommand com = new SqlCommand(queryStr, con);
    SqlDataReader sdr = com.ExecuteReader();
    while(sdr.Read())
    {
       this.textbox2.Text = sdr.GetValue(0).ToString();
    }
