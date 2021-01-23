    Data = new List<List<double>>();
    for (int i = 0; i < columnCount; i++)
    {
      List<double> column = new List<double>();
      for (int j = 0; j < rowCount; j++)
      {
        //not really sure if this is the correct code here
        //that would depend on your logic
        column.Add((probabilityList[j]) * K); 
      }
      Data.Add(column);
    }
