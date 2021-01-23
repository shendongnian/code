    string tempFile = Path.GetTempFileName();
    using(var sr = new StreamReader("file.txt"))
    {
      using(var sw = new StreamWriter(tempFile))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
             if(line != "BlaBlaBla")
                 sw.WriteLine(line);
        }
      }
    }
