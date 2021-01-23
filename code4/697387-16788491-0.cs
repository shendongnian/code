    string input = "car[brand=saab][wheels=4]";
    string product = "";
    Dictionary<string, string> props = new Dictionary<string, string>();
    foreach (Match m in Regex.Matches(input, @"^(\w+)|\[(\w+)=(.+?)\]"))
    {
        if (String.IsNullOrEmpty(product))
            product = m.Groups[1].Value;
        else
            props.Add(m.Groups[2].Value, m.Groups[3].Value);
    }
