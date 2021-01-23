    private void button1_Click(object sender, EventArgs e)
    {
    	string input = label1.Text.Trim();
    	string conn = "server=46.28.110.147;user=______;password=________;database=________;";
    	string sql = "SELECT numbers FROM domestic WHERE used=0 ORDER BY numbers LIMIT 1; UPDATE domestic SET used = 1 WHERE numbers = @numbers";
    	MySqlConnection myconn = new MySqlConnection(conn);
    	MySqlCommand cmd = new MySqlCommand(sql, myconn);
    	MySqlDataAdapter da = null;
    	DataSet ds = null;
    	DataTable dt = null;
    
    	cmd.Parameters.Add("numbers", SqlDbType.VarChar, 50).Value = input;
    
    	da = new MySqlDataAdapter(cmd);
    	ds = new DataSet();
    	da.Fill(ds);
    
    	if (ds.Tables.Count > 0) {
    		if (ds.Tables(0).Rows.Count > 0) {
    			dt = ds.Tables(0);
    			label1.Text = dt.Rows(0)(0) + "";
    		}
    	}
    }
