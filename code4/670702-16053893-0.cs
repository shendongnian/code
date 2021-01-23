    string s = "Here comes number on the consignment 1020289847AB.";
    Regex regex = new Regex(@"\d{10}\D{2}");
    Match match = regex.Match(s);
            
    if (match.Success)
    {
        Console.WriteLine(match.Value);
    }
