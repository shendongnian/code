    try
    {
       using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["STRING"].ConnectionString))
       {
         using (SqlCommand cmd = new SqlCommand("dbo.Res_User", con))
         {
           cmd.CommandText = "INSERT INTO Res_User(username, password, key_pin) SELECT '" + username + "' , dbo.fnEncDecRc4('" + pin + "','" + password + "'), '" + pin + "'";
           con.Open();
           cmd.ExecuteNonQuery();
    
           MessageBox.Show("Added", "Information", MessageBoxButtons.OK);
    
           cmd.CommandText = "SELECT password FROM Res_User WHERE username = @username AND key_pin = @pin AND password = dbo.fnEncDecRc4(@pin, @password)";
           cmd.Parameters.AddWithValue("@username", username);
           cmd.Parameters.AddWithValue("@pin", pin);
           cmd.Parameters.AddWithValue("@password", password);
           cmd.ExecuteNonQuery();
    
           using (SqlDataReader reader = cmd.ExecuteReader())
           {
               if (reader.HasRows)
               {
                   //successfully validated.
               }
           }
