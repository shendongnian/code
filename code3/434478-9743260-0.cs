    // first is exe of executing program
    string[] args = Environment.CommandLine.Split('/').Skip(1).ToArray();
    foreach (string arg in args)
    {
        string value = arg.Trim();
        switch (value)
        {
            case "f":
                //...
                continue;
        }
        if (value.StartsWith("d:"))
        {
            value = value.Substring(2);
            // ...
            continue;
        }
    }
