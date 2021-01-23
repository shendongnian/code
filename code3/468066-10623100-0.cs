    try 
      { 
        MySqlDataReader myReader = cmd.ExecuteReader(); 
         
        // Always call Read before accessing data. 
        while (myReader.Read())  
        { 
          //This will get the value of the column "name"
          Console.WriteLine(myReader.GetString(myReader.GetOrdinal("name"))); 
        } 
     
        // always call Close when done reading. 
        myReader.Close(); 
     
        // Close the connection when done with it. 
        } 
      finally 
      { 
        con.Close(); 
      } 
