    public IEnumerable<string> ReadFile(string filePath)
    {
       using (StreamReader rdr = new StreamReader(filePath))
       {
           string line;
           while ( (line = reader.ReadLine()) != null)
           {
              yield return line;
           }
       }
    }
