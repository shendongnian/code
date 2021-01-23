       var yourParameter = ....; //Your Value from your event , the value of textbox
       var mySelectQuery = ....; //Enter name stored procedure
       var myConnectionString = ....; //Enter string connection
       using(var myConnection = new SqlConnection(myConnectionString))
       {
       using(var myCommand = new SqlCommand(mySelectQuery, myConnection))
       {
          myConnection.Open();
          myCommand.CommandType =  CommandType.StoredProcedure;
          myCommand.Parameters.Add(
		new SqlParameter("@YourParameter", yourParameter));
          SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while(myReader.Read()) 
          {
            Console.WriteLine(myReader.GetString(0));
          }
       }
       } 
