    IEnumerable<KeyValuePair<int, double>> ReadFrames(string path)
    {
        foreach (var line in File.ReadLines(path))
        {
           var parts = line.Split(' '); 
           yield return new KeyValuePair<int, double>(
               int.Parse(parts[0]),
               double.Parse(parts[1]));
        }
    }
    var frames = new Dictionary<int, double>(ReadFrames("yourfile.txt"));
    var frameIds = frames.Keys;
    var values = frames.Values;
