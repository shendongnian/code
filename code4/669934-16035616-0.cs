    //one.two..three...four....five (dots = spaces)
    string input = "one two  three   four    five";
      
    string result = new Regex(@"\s{2,}").Replace(input, delegate(Match m)
    {
        int substring = Math.Max(2, m.Value.Length - 2);
        if (m.Value.Length == 2) substring = 1;
        string str = m.Value.Substring(substring);
        return str;
    });
