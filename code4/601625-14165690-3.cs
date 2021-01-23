    var matrixData = new double[rowCount, columnCount];
    for (int i = 0; i < columnCount; i++)
    {
      for (int j = 0; j < rowCount; j++)
      {
        matrixData[j, i] = ((probabilityList[j]) * K); 
      }
    }
