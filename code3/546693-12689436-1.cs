    public static int GetMaxForFile(int i) 
    { 
        string path = GetPath(i); 
        var lines = new List<string>(File.ReadAllLines(path));
        // you MUST perform all of your processing here ... you have to let go
        // of the List<string> variable ...
        int max = Math.Max(max, lines.Max(t=>int.Parse(t)));
        // this may be redundant, but it will cause GC to clean up immediately
        lines.Clear();
        lines = null;
        return max;
    } 
