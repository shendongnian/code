       private void AddToDatabase(string fileName){
        if(fileName.Equals("yourfirstFile"))
         {
          using (OleDbConnection connection =
                new OleDbConnection(excelConnectionString))
                {
                    connection.Open();
                    CheckNumeberOfSheets(connection);
                }
          }
        else if(fileName.Equals("yoursecondfile"))
         {
          using (OleDbConnection connection =
                new OleDbConnection(excelConnectionString2))
                {
                    connection.Open();
                    CheckNumeberOfSheets(connection);
                }
          }
        }
