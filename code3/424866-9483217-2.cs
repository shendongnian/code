    if (reader.Read())
    {
      var values = new object[reader.FieldCount];
      reader.GetValues(values);
      
      for (int i = 0; i < values.Count ; i++)
      {
        if (values[i] == null)
           continue;  
        listBox2.Items.Add(values[i].ToString());      
      }
    }
