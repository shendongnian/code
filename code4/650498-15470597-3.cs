    StringBuilder sb = new StringBuilder();
    foreach (string line in input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
    {
        // notice different regex, i.e.:
        // new paragraph stars with `<p>x:y` and ends with `</p>`
        if (Regex.IsMatch(line, @"^\<p\>[0-9]\:[0-9].+\</p\>$"))
        {
            sb.Append(line);
        }
        else // continuation
        {
            sb.Append(line);
            sb.AppendLine(); // insert line break
        }
    }
    string result = sb.ToString();
