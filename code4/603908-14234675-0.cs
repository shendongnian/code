    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        ServerConnection svrConnection = new ServerConnection(sqlConnection);
        Server server = new Server(svrConnection);
    
        string script = File.ReadAllText("upgradeDatabase.sql");
        string[] singleCommand = Regex.Split(script, "^GO", RegexOptions.Multiline);
        StringCollection scl = new StringCollection();
        foreach(string t in singleCommand)
        {
            if(t.Trim().Length > 0) scl.Add(t.Trim());
        }
        try
        {
            int[] result = server.ConnectionContext.ExecuteNonQuery(scl, ExecutionTypes.ContinueOnError);
            // Now check the result array to find any possible errors??
         }
         catch (Exception ex)
         {
             //handling and logging for the errors are done here
         }
    }
