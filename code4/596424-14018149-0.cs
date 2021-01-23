    string inp = "hai how are you?";
    StringBuilder strb = new StringBuilder();
    List<char> charlist = new List<char>();
    for (int c = 0; c < inp.Length; c++ )
    {
        if (inp[c] == ' ' || c == inp.Length - 1)
        {
            if (c == inp.Length - 1)
                charlist.Add(inp[c]);
            for (int i = charlist.Count - 1; i >= 0; i--)
                strb.Append(charlist[i]);
            strb.Append(' ');
            charlist = new List<char>();
        }
        else
            charlist.Add(inp[c]);
    }
    string output = strb.ToString();
