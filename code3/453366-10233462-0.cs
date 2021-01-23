    string readFile =  @"C:\****\temperature.txt");
    string writeFile = @"C:\****\temperature2.txt");
    List<string> lines = new List<string>lines;
    ....
    string sr = new StreamReader(readFile);
    foreach (string line in sr.ReadAllLines())
    {
       int c = line.IndexOf("=");
       if ( c >= 0 ) {
          lines.Add(line.SubString(c+1);
       }
    }
    if ( lines.Count > 0 ) {
      System.IO.File.WriteAllText(writeFile, 
         string.Join(Environment.NewLine, lines.ToArray*());
    }
