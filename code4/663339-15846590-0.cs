            public string MyPath1; // put these way up at the top of the class
            public string MyPath2;
    public voice ReadConfig(string txtFile)
    {
        using (StreamReader sr = new StreamResder(txtFile))
        {
            string line;
            while ((line = sr.ReadLine()) !=null)
            {
                var dict = File.ReadAllLines(txtFile)
                               .Select(l => l.Split(new[] { '=' }))
                               .ToDictionary( s => s[0].Trim(), s => s[1].Trim());
            }
            MyPath1 = dic["MyPathOne"];
            MyPath2 = dic["MyPathTwo"];
        }
    }
