    private void btnLogin_Click(object sender, EventArgs e) {
    	string username = txtLogin.Text;
    	string password = ORFunc.GetMD5Hash(txtPassword.Text);
    	
    	SqlCall sqlcall = new SqlCall("SELECT * FROM orUsers WHERE username = '" + username + "' AND pass = '" + password + "'");
    	
    	try {
    		MySqlDataReader orRead = sqlcall.execute();
    		while (orRead.Read())
    		{
    			MessageBox.Show(orRead["id"].ToString());
    		}
    		sqlcall.close();
    	} catch (Exception ex) {
    		// dostuff
    	}
    }
