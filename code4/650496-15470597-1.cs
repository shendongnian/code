    StringBuilder sb = null;
    foreach (string line in data)
    {
        // new paragraph
        if (Regex.IsMatch(line, @"^[0-9]\:[0-9].+$"))
        {
            sb = new StringBuilder(line);
        }
        else // continuation
        {
            sb.Append(line);
        }
    }
    string result = sb.ToString();
