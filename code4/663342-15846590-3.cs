    public string MyPath1; // (Put these at the top of the class.)
    public string MyPath2;
    public voice ReadConfig(string txtFile)
    {
        var dict = File.ReadAllLines(txtFile)
                       .Select(l => l.Split(new[] { '=' }))
                       .ToDictionary( s => s[0].Trim(), s => s[1].Trim());  // read the entire file into a dictionary.
        MyPath1 = dict["MyPathOne"];
        MyPath2 = dict["MyPathTwo"];
    }
