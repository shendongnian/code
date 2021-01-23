    string subject = "text > token 1 > token 2 > token 3 > token 4 > text";
    string pattern = @"(?=(>[^>]+)>)";
    Match m = Regex.Match(subject, pattern);
    List<string> items = new List<string>();
    while (m.Success)
    {
        items.Add(m.Groups[1].ToString());
        m = m.NextMatch();
    }
    List<string> results = new List<string>();
         
    for (int i = 0; i < items.Count(); i++)
    {
        string temp = "";
        for (int j = i; j < items.Count(); j++)
        {
            temp += items[j];
            results.Add(temp + '>');
        }
    }
    results.ForEach(Console.WriteLine);
