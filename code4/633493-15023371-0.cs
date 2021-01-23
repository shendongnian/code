    strign pattern = "england";
    IList<string> result = new List<string>();
    using (StreamReader sr = new StreamReader("TestFile.txt")) 
    {
        string line;
        while ((line = sr.ReadLine()) != null) 
        {
            if (line.Contains(pattern)
            {
               result.Add(line);
            }
        }
    }
