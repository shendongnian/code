    Dictonary<string, int> counts = new Dictionary<string, int>();
    foreach(string value in list)
    {
      if(counts.ContainsKey(value))
        counts[value]++;
      else
        counts[value] = 1;
    }
    foreach(KeyValuePair<string, int> kvp in counts)
      System.Diagnostics.Debug.WriteLine("\"{0}\" occurs {1} time(s).", kvp.Key, kvp.Value));
