    var sb = new StringBuilder();
    for(UInt16 i = 0; i < UInt16.MaxValue; i++)
    {
        string str = Convert.ToChar(i).ToString();
        if (Regex.IsMatch(str, @"\d"))
            sb.Append(str);
    }
    Console.WriteLine(sb.ToString());
