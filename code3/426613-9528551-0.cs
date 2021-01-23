    SqlConnection thisConnection = new
            SqlConnection(@"Server=(local)\sqlexpress;Integrated Security=True;" +
                      "Database=northwind");
            thisConnection.Open();
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "Select count(*) from UserDetails
    WHere UserName = "+txtUsername.text.trim().toLower() + " and Password = " +txtPassword.text.trim().toLower();
            Object countResult = thisCommand.ExecuteScalar();
            Console.WriteLine("Count of Customers = {0}", countResult);
    
            thisConnection.Close();
