    List<string> lines = new List<string>();
    
    using (StreamReader reader = new StreamReader("example.txt"))
    {
        while(!reader.EndOfStream)
        {
            lines.Add(reader.ReadLine());
        }
    }
