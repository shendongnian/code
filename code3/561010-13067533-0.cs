    string s = "XXX1XXX2XXX3XXX4";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < s.Length; ++i)
    {
        sb.Append(s[i]);
            
        if ((i < s.Length-1) && ((i+1) % 4) == 0)
        {
            sb.Append('-');
        }
    }
    s = sb.ToString();
    Console.WriteLine(s);
