    int admin = 23;
    
      SqlConnection thisConnection = new SqlConnection(
    "Data Source=...;Persist Security Info=True;User ID=myusername;Password=mypassword");
     SqlCommand nonqueryCommand = thisConnection.CreateCommand();
    thisConnection.Open();
     nonqueryCommand.CommandText = "INSERT INTO Account (Username,Password,AdministratorId) VALUES (@username,@password,@admin)";
    
    nonqueryCommand.Parameters.Add("@username", SqlDbType.VarChar, 20);
    nonqueryCommand.Parameters["@username"].Value = UsernameTextbox.Text.ToString();
    nonqueryCommand.Parameters.Add("@password", SqlDbType.VarChar, 15);
    nonqueryCommand.Parameters["@password"].Value = PasswordTextbox.Text.ToString();
    nonqueryCommand.Parameters.Add("@admin", SqlDbType.Int);
    nonqueryCommand.Parameters["@admin"].Value = admin;
    
     nonquerycommand.ExecuteNonQuery();
    
    
     thisConnection.Close();
