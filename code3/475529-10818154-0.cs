    public string ExtractNumber(string filePath)
    {
      Regex r = new Regex(@"data-Rowkey=(\d+)")
      using (StreamReader reader = new StreamReader(filePath))
      {
        string line; 
        while ((line = reader.ReadLine()) != null)
        {
          Match match = r.Match(line);
          if (match.Success) return match.Groups[1].Value;
        }
      }
    }
