    // Start a TransactionScope to handle all/or/nothing scenario
    using(TransactionScope scope = new TransactionScope())
    {
        using(SqlConnection mySqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DBLocal"].ConnectionString))
        {
              SqlCommand cmdIdent = new SqlCommand("SELECT SCOPE_IDENTITY()", mySqlConnect);
              SqlCommand command = mySqlConnect.CreateCommand();
              // Append the SELECT SCOPE_IDENTITY as a second command on this text.....
              command.CommandText = "INSERT INTO Spectras VALUES"
                                             + "(@DateTime, "
                                             + "......"
                                             + ";SELECT SCOPE_IDENTITY();"
              mySqlConnect.Open();
              // HERE YOU EXECUTE THE COMMAND AND GET BACK THE LAST IDENTITY USED 
              SqlDataReader reader = command.ExecuteReader();
              if (reader.HasRows)
              {
                  reader.Read();
                  int spectraID = Convert.ToInt32(reader[0]);
                  // Ready to start the insert of points
        
                  SqlCommand cmdPoints = new SqlCommand("INSERT INTO DataPoints " + 
                                          "VALUES (@ID, @IDX, @VAL)", mySqlConnect);
                  cmdPoint.Parameters.AddWithValue("@ID",spectraID);
                  cmdPoint.Parameters.AddWithValue("@IDX",0);
                  cmdPoint.Parameters.AddWithValue("@VAL",0);
        
                  foreach(DataPoint dp in DataPoints)
                  {
                      cmdPoint.Parameters["@IDX"].Value = dp.Index);
                      cmdPoint.Parameters["@VAL"].Value = dp.Value);
                      cmdPoint.ExecuteNonQuery();
                  }
            }      
        }
        scope.Complete(); // This will write everything on the database
       
    }
