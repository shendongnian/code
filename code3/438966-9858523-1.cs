    var re = new Regex(pattern);
    foreach (var input in inputs)
    {
        Console.WriteLine("Input: " + input);
        var query = from Match m in re.Matches(input)
                    from g in re.GetGroupNames().Skip(1)
                    where m.Groups[g].Success
                    select new
                    {
                        GroupName = g,
                        Value = m.Groups[g].Value
                    };
        foreach (var item in query)
        {
            Console.WriteLine("{0}: {1}", item.GroupName, item.Value);
        }
        Console.WriteLine();
    }
