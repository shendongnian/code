    using(SqlConnection conn = new SqlConnection("yourconnectionstring"))
    {
        SqlCommand getRequest = new SqlCommand("SELECT gameRequestUser FROM UserData Where " + 
                                               "userName=@user", conn); 
        conn.Open(); 
        getRequest.Parameters.AddWithValue("@user",Session["userName"].ToString()) 
        SqlDataReader reader = getRequest.ExecuteReader(); 
        while (reader.Read()) { 
            user = reader.GetValue(0).ToString().Trim(); 
        } 
    }
