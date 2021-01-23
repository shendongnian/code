    string[] lines = File.ReadAllLines(path1);
    using(StreamWrite sw = new StreamWriter(path1))
    {
        foreach(string line in lines)
        {
            string lineOut = line;
            if (line == "25") 
               lineOut = "27"; 
            sw.WriteLine(lineOut);
        }
        sw.Flush();
    }
