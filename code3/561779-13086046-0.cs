    using (StreamReader sr = new StreamReader(filePath))
    {
      while (true)
      {
        string line = sr.ReadLine();
        if (string.IsNullOrEmpty(line))
          break;
      }
    }
