    var mainData = new List<List<double>>();
    for (int i = 0; i < columnCount; i++)
    {
      List<double> innerList = new List<double>();
      for (int j = 0; j < rowCount; j++)
      {
        innerList.Add((probabilityList[j]) * K); 
      }
      mainData.Add(innerList);
    }
