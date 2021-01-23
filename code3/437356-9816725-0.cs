    private void PrintVariables(Dictionary<string, object> variables)
    {
        Console.WriteLine(string.Join(
            " and ", variables.Select(kvp => string.Format("{0} = {1}",
                                                           kvp.Key,
                                                           kvp.Value))));
    }
