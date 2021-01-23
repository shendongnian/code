    List<string> ReadFile(string path)
    {
       TextReader tr = new StreamReader(path);
       string line;
       List<string> lines = new List<string>();
       while((line=tr.ReadLine())!=null)
       {
           //if this was a CSV, you could string.split(',') here
           lines.add(line);
       }
       return lines;
    }
