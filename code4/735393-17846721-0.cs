    string paramsList;
    try
    {
        string parms = string.Join(", ",  BuildParameters.Select(t => t.ToString())));
        paramsList = String.Format(
            "Calling process containing IEnumerable extension method - These parameters will be used: {0}",
            parms);
        Console.WriteLine(paramsList);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception!");
        Console.WriteLine(ex.ToString());
    }
