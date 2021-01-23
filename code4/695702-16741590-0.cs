    private void button1_Click(object sender, EventArgs e)
    {
    	string input = label1.Text.Trim();
    	string conn = "server=46.28.110.147;user=______;password=________;database=________;";
    	MySqlConnection myconn = new MySqlConnection(conn);
    	string sql = "SELECT numbers FROM domestic WHERE used=0 ORDER BY numbers LIMIT 1";
    	MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
    	DataTable dt = new DataTable();
    	da.Fill(dt);
    
    	label1.Text = dt.Rows[0][0] + "";	// Recovers the value and puts into label.
    	
    	MySqlCommand cmd = new MySqlCommand(sq2, myconn);
    	string sq2 = "UPDATE domestic SET used = 1 WHERE numbers = '" + label1.Text +"'";
    	myconn.Open();
    	cmd.ExecuteNonQuery();				// Updates database to set used = 1 for recovered number.
    	myconn.Close();
    }
