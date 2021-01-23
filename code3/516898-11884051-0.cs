    Parallel.For(1, linii.Length, index =>
    {
      alResult = CSVParser(linii[index], txtDelimiter, txtQualifier);
    
      lock (dtResult)
      {
        DataRow drRow = dtResult.NewRow();
        for (int i = 0; i < alResult.Count; i++)
        {
           drRow[i] = alResult[i];
        }
        dtResult.Rows.Add(drRow);
      }
    });
