    while(reader.Read())
    {
      var rawValues = reader.GetValues();
      var values = new object[rawValues.Length];
      for (i=0; i < rawValues.Length; i++)
      {
        var value = rawValues[i];
        if(value != null && value is string && value.Length > 100]
          values[i] = value.SubString(0, 100);
      }
      //now do whatever you want with the values
    }
