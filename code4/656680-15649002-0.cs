    try
    {
      ///Open connection before we can read
      dataConnection.Open();
    
      ///Prepare to read
      reader = dataCommand.ExecuteReader();
    
      // Call Read before accessing data.
      while (reader.Read())
      {
        List<string> myTestData = new List<string>();
        for (int i = 0; i < howManyColumns; i++)
        {
          ///Add columns to myTestData list
          myTestData.Add(reader.GetValue(i).ToString());
        }
        ///Add myTestData list to dataRows
        dataRows.Add(myTestData);
      }
    }
    catch (SqlException exSql)
    {
      Program.displayExError(exSql, true);
    }
