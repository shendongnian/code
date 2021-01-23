    List<string> str = File.ReadAllText(@"completefilepath").Split('\n').ToList();
    List<string> updatedValues =   new List<string>();
    foreach (var value in str)
    {
          int val = 0;
          if (int.TryParse(value, out val))
          {
             updatedValues.Add((val + 1).ToString());        
          }
    }
    File.WriteAllLines(@"completefilepath", updatedValues);
