    Dictionary<string, string> errors;
    if (!matchesLists.TryGetValue("Errors", out errors))
    {
        errors = new Dictionary<string, string>();
        matchesLists["Errors"] = errors;
    }
    foreach (var entry in GetInnerTextMatches(webDriver))
    {
        errors.Add(entry.Key, entry.Value);
    }
