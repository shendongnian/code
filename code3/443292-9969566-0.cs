    var items = new List<string>();
    var delimiters = new List<string>();
    items.AddRange(Regex.Split(text, @"(?<=/)|(?=/)|(?<=\*)|(?=\*)"));
    for (int i = 0; i < items.Count; )
    {
        string item = items[i];
        if (item == "*" || item == "/")
        {
            delimiters.Add(item);
            items.RemoveAt(i);
        }
        else if (item == "")
        {
            items.RemoveAt(i);
        }
        else
        {
            i++;
        }
    }
