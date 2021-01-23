    try
    {
    	string Conn = "server=.;User Id=sa;" + "pwd=passs;";
    	SqlConnection con = new SqlConnection(Conn);
    	con.Open();
    
    	SqlCommand cmd = new SqlCommand();
     //   da = new SqlDataAdapter("SELECT * FROM sys.database", con);
    	cmd = new SqlCommand("SELECT name FROM sys.databases", con);
       // comboBox1.Items.Add(cmd);
    	SqlDataReader dr;
    	dr = cmd.ExecuteReader();
    	if (dr.HasRows)
    	{
    		while (dr.Read())
    		{
    			//comboBox2.Items.Add(dr[0]);
    			comboBox1.Items.Add(dr[0]);
    		}
    	}
    
       // .Items.Add(da);
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
