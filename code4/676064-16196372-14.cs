    double GetFrameValue(string path, int limit)
    {
        string [] parts;
        foreach (var line in File.ReadLines(path))
        {
           parts = line.Split(' '); 
           var frameId = int.Parse[0];
           if (frameId >= limit)
           {
               break;
           }
        }
        return double.Parse(parts[1]);
    }
