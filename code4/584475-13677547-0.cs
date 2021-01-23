    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();
     System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
     connection.ConnectionString = connectionString; //put your connection string
     command.CommandText = @"
         UPDATE table SET somecol = somevalue;
         insert into someTable values(1,'test');";
     command.CommandType = System.Data.CommandType.Text;
     command.Connection = connection;
    
     try {
        connection.Open();
     } catch (System.Exception exception) {
        
     } finally {
        command.Dispose();
        connection.Dispose();
     }
