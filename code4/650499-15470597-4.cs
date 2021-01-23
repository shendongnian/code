    StringBuilder sb = new StringBuilder();
    foreach (string line in input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
    {
        sb.Append(line.Trim());
        // notice different regex, i.e.:
        // new paragraph stars with `<p>x:y` and ends with `</p>`
        if (!Regex.IsMatch(line, @"^\<p\>[0-9]\:[0-9].+\</p\>$"))
        {
             sb.AppendLine(); // insert line break
        }
    }
    string result = sb.ToString();
