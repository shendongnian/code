    string strConnectionString = ConfigurationManager.ConnectionStrings["ASPNETDBConnectionString1"].ConnectionString;
    
        SqlConnection myConnect = new SqlConnection(strConnectionString);
    
        string strCommandText = "SELECT date, starttime, endtime, planner FROM bookings WHERE UserId =@UserId";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
      cmd.Parameters.AddWithValue("@UserId", UserId);
    
        myConnect.Open();
        SqlDataReader reader = cmd.ExecuteReader();  
        myGridView.DataSource = reader;
        myGridView.DataBind();
    
        reader.Close();
        myConnect.Close();
