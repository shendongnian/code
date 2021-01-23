    List<String> lines = new List<string>();
    string line;
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
            
    while ((line = file.ReadLine()) != null)
    {
        lines.Add(line);
    }
    lines.RemoveAll(l => l.Contains(",,,,,"));
