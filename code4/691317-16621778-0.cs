    var sb = new StringBuilder();
    for(Int16 i = 0; i < Int16.MaxValue; i++)
    {
        string str = Convert.ToChar(i).ToString();
        if (Regex.IsMatch(str, @"\d"))
            sb.Append(str);
    }
    Console.WriteLine(sb.ToString());
