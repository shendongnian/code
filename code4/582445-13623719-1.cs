    static readonly Regex re = new Regex("^[012]00", RegexOptions.Compiled);
    ...
    while (...)
    {
        if(re.IsMatch(line))
        {
            list.Add(line); // Add to list.
            Console.WriteLine(line); // Write to console.
        }
    }
