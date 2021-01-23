    for (int intCounter = 0; intCounter < reader.FieldCount; intCounter++)
    {
                           
      lstColumns.Add(reader.GetName(intCounter));
      columns.Add(string.Join(",",reader.GetName(intCounter).ToArray().ToString().ToList()));
      Console.WriteLine(lstColumns[intCounter]);
    }
