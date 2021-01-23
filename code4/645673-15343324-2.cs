    using (var reader = new StreamReader(inputfile))
    {
      using (var writer = new StreamWriter(outputfile))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
           if (line.IndexOf("string1") == -1 && line.IndexOf("string2") == -1)
           {
              writer.WriteLine(line);
           }
        }
      }
    }
    File.Move(outputFile, inputFile);
