    private static string[] ReadAllLines(string fileName)
    {
      using (var fs = new FileStream(fileName, FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.ReadWrite))
      {
        var reader = new StreamReader(fs);
        //read all at once and split, or can read line by line into a list if you prefer
        var allLines = reader.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" },
                                                StringSplitOptions.None);
        return allLines;
      }
    }
