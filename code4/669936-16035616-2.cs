    //one.two..three...four....five..... (dots = spaces)
    string input = "one two  three   four    five     ";
      
    string result = new Regex(@"\s{2,}").Replace(input, delegate(Match m)
    {    
        if (m.Value.Length > 2)
        {    
            int substring = m.Value.Length - 2;
            //if there are two spaces, just remove the one
            if (m.Value.Length == 2) substring = 1;
            string str = m.Value.Substring(m.Value.Length - substring);
            return str;
        }
        return m.Value;
    });
