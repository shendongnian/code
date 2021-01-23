    var command = new SqlCommand()
    {
      CommandText = "SELECT * FROM Table";
      Connection = new SqlConnection("InsertConnectionString");
    };
    
    using(var reader = command.ExecuteReader())
    {
      while(reader.Read())
      {
        var values = new object[reader.FieldCount];
        reader.GetValues(values);
        
        // process values of row
      }
    }
