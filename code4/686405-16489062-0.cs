    string FixedName(string name)
    {
        name = name.Trim();
        var prefixes = new string[] { "Mrs. ", "Mrs ", "Mr. ", "Mr ", "Dr. ", "Dr " };
        foreach (var prefix in prefixes)
        {
            if (name.StartsWith(prefix, true, CultureInfo.InvariantCulture))
            {
                name = name.Substring(prefix.Length).Trim();
                break;
            }
        }
        return name;
    }
