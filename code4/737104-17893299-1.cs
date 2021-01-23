    string GetLine(string fileName, int line)
    {
       using (var sr = new StreamReader(fileName)) {
           for (int i = 1; i < line; i++)
              sr.ReadLine();
           return sr.ReadLine();
       }
    }
