    var lines  = File.ReadLines(@"filename");
    foreach (string line in lines)
    {
        // Then split each line
        var str = line.Split('|');  // str contains list of splitted string
        
        // then save it to db
       using ( var c = new OracleConnection("connectionString") )
       {
          c.Open();
         // check flag
         if ( str [2] == 'A' ) 
         {
          // prepare your sql with splitted array
          var command = c.CreateCommand();
          command.Text = "INSERT INTO table(column) values(:col1)";
          command.Parameters.AddWithValue("col1", str[0])
          command.ExecuteNonQuery();
        }
 
       }
    }
