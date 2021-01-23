    static List<string> LinesBetween(string path, string start, string end)
    {
        var lines = new List<string>();
        var foundStart = false;
    
        foreach (var line in File.ReadLines(path))
        {
            if (!foundStart && line == start)
                foundStart = true;
    
            if(foundStart)
                if (line == end) break;
                else lines.Add(line);
        }
    
        return lines;
    }
