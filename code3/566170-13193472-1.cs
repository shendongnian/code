         OleDbConnection connection = new OleDbConnection("old conn string>");                
         connection.Open();
         //do somthing with db 1
         connection.Close();
        
         //Change the connection string
         connection.ConnectionString="<new connection string>";
        
         connection.Open();
         //do somthing with db 2
         connection.Close();
