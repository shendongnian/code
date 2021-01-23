	string connString = "Server=localhost;Port=3306;Database=communications;Uid=root;password=pass;";
    
	using(MySqlConnection conn = new MySQLConnection(connString))
       {
       using(MySQlCommand command = conn.CreateCommand())
         {
          command.CommandText = "SELECT ...";
          conn.Open();
          using(MySqlDataReader reader = command.ExecuteReader())
               {
                 //process rows...
               }
         }
       }
