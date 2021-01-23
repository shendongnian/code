    // we need to alloc/init the streams inside for using blocks so they're properly disposed of
    List<string> grades = new List<string>();
    using (StreamReader inFile = new StreamReader("rec.in"))
    {
         string line;
         while ((line = inFile.ReadLine()) != null)
         {
             string[] tokens = line.Split(' '); // split line on whitespace
             if (tokens.Length > 7)
                 grades.Add(tokens[7]);
         }
    }
    
    using (StreamWriter outFile = new StreamWriter("rec.out"))
    {
          foreach (string s in grades)
              outFile.WriteLine(s);
    }
