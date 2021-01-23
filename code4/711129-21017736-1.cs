 	Sqlcommand cmd = new SqlCommand(Get_Data, thisConnection)
	try {
	    string connectionstring = "@"
	    Server = (local) Database = Sample_dbTrusted_Connection = Yes;
	    "";
	    SqlConnection thisConnection = new SqlConnection(connectionstring);
	    thisConnection.Open();
	    string Get_Data = "SELECT * FROM emp";
	    SqlCommand cmd = new SqlCommand(Get_Data, thisConnection);
	    SqlDataAdapter sda = new SqlDataAdapter(cmd);`
	    DataTable dt = new DataTable("emp");
	    sda.Fill(dt);
	    MessageBox.Show("connected");
	    //dataGrid1.ItemsSource = dt.DefaultView;           
	} catch {
	    MessageBox.Show("db error");
	}
    
 
  
