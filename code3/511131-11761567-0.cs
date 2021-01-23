    int NumberOfRecordsToRetrieve = 10000;
    int StartRecordNumber = 1;
    bool EndOfFile = false;
  
     string queryString = "SELECT OrderID, CustomerID FROM Orders WHERE RECNO() BETWEEN @StartRecordNumber AND @EndRecordNumber"; 
    While (!EndOfFile)
    {
         using (OleDbConnection connection = new OleDbConnection(connectionString)) 
         { 
             OleDbCommand command = new OleDbCommand(queryString, connection); 
             command.Parameters.Add(new OleDbParameter("@StartRecordNumber", StartRecordNumber)); 
             command.Parameters.Add(new OleDbParameter("@EndRecordNumber", StartRecordNumber + NumberOfRecordsToRetrieve)); 
 
             connection.Open(); 
             OleDbDataReader reader = command.ExecuteReader(); 
 
              EndOfFile = true;
              while (reader.Read()) 
              { 
                   EndOfFile = false
              
                   //Retrieve records here and do whatever process you wish to do
               } 
               reader.Close(); 
               StartRecordNumber += NumberOfRecordsToRetrieve;
         } 
    }
