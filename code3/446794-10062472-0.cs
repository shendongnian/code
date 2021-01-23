    string[] lines = str.Split(new char[] { '\r', '\n'} , 
        StringSplitOptions.RemoveEmptyEntries);
    Dictionary<string, string> dict = lines.ToDictionary(
        line => line.Split(':').First(), 
        line => line.Split(new char[] { ':' }, 2).Last().Trim());
