    public Dictionary<string, string> SplitTheStrings(s) {
        var d = new Dictionary<string, string>();  
        var a = s.Split('&');
        foreach(string x in a) {
            var b = x.Split('=');
            d.Add(b[0], b[1]);
        }
        return d;
    }
