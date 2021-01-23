    function GetIntValue()
    {
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
    
    	con.Open();
    
    	SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Employees",con);
    	int numberOfEmployees = (int)cmdCount.ExecuteScalar();
    	Response.Write("Here are the " + numberOfEmployees.ToString() + " employees: <br><br>");
    
    	SqlCommand cmd = new SqlCommand("SELECT * FROM Employees",con);
    	SqlDataReader dr = cmd.ExecuteReader();
    	while(dr.Read()) {
    		Response.Write(dr["LastName"] + "<br>");
    	}
    	con.Close();
    }
