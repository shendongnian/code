    StringBuilder sb = new StringBuilder();
    foreach (string line in input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
    {
        // new paragraph
        if (Regex.IsMatch(line, @"^\<p\>[0-9]\:[0-9].+$"))
        {
            sb.Append(line);
        }
        else // continuation
        {
            sb.Append(line);
            sb.AppendLine();
        }
    }
    string result = sb.ToString();
