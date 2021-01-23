        SqlTransaction trans; 
        try
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            trans = connection.BeginTransaction(); 
            foreach (var commandString in sqlCommandList)
            {
                SqlCommand command = new SqlCommand(commandString, connection,trans);
                command.ExecuteNonQuery();
            }
            trans.Commit(); 
        }
        catch (Exception ex) //error occurred
        {
            trans.Rollback();
            //Handel error
        }
 
