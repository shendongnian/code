    protected void Search_Click(object sender, EventArgs e) 
    { 
        string IDnumber = mechantNumber.Text; 
        string selectSQL = "SELECT * FROM Authors Where MID=@num"; 
        using(SqlConnection con = new SqlConnection
                          (System.Configuration.ConfigurationManager.ConnectionStrings
                           ["Server"].ConnectionString))
        {
             SqlDataReader reader; 
             con.Open(); 
             SqlCommand cmd = new SqlCommand(selectSQL, con); 
             cmd.Parameters.AddWithValue("@num", IDNumber);
             reader = cmd.ExecuteReader(); 
             while (reader.Read()) 
             { 
                  QualVol.Text = reader["TotalVolume"].ToString(); 
             } 
             reader.Close(); 
        } 
    } 
