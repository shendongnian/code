    var matches = Regex.Matches(responseFromServer, m, RegexOptions.IgnoreCase);
    foreach (var item in matches)
    {
        var match = item as Match;
        if (match.Success)
        {
            listBox1.Items.Add(match.Groups[2]Value.ToString());    
        }
        if (list.Count % 50 == 0)
        {
            n++;
        }
    }
