    string[] lines = File.ReadAllLines(path1);
    using(StreamWrite sw = new StreamWriter(path1))
    {
        foreach(string line in lines)
        {
            if (line == "25") 
               line = "27"; 
            sw.WriteLine(line);
        }
        sw.Flush();
    }
