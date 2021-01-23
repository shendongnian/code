      String fileName = @"c:\MyFile.txt";
      Dictionary<string, string> stroka = new Dictionary<string, string>();
    
      using (TextReader reader = new StreamReader(fileName)) {
        String key = null;
        Boolean isValue = false;
    
        while (reader.Peek() >= 0) {
          if (isValue)
            stroka.Add(key, reader.ReadLine());
          else
            key = reader.ReadLine();
    
          isValue = !isValue;
        }
      }
