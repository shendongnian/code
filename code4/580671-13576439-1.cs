    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    using (CsvReader reader = new CsvReader("Input.csv"))
    {
      foreach (string[] record in reader.DataRecordsAsStrings)
      {
        //assuming each record contains exactly 2 columns, under index 0 and 1
        string key = record[0];
        string value = record[1];
        List<string> targetList = null;
        if (!dict.TryGetValue(key, out targetList))
        {
          targetList = new List<string>();
          dict.Add(key, targetList);
        }
        targetList.Add(value);
      }
    }
    List<string> output = new List<string>();
    foreach (KeyValuePair<string, List<string>> kv in dict)
    {
      string outputCsvLine = kv.Key + "," + string.Join(",", kv.Value);
      output.Add(outputCsvLine);
    }
    System.IO.File.WriteAllLines("output.csv", output);
