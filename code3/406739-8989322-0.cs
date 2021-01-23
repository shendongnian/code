    string test = "test";
    var array = {{test,"",test}, {test, test, test,"",test}};
    
    string[] TransformRow(string[] inputRow)
    {
      return intputRow.Where(cell => cell != string.Empty).ToArray();
    }
    
    var validArray = array.Select(row => TransformRow(row));
