    IEnumerable<IGrouping<string, string>> fields =
        Regex.Split(input, @"\r?\n|\r", RegexOptions.None)
        .Where(s => !String.IsNullOrWhiteSpace(s))
        .Select(x => x.Split(new [] {'='}, 2, StringSplitOptions.RemoveEmptyEntries))
        .GroupBy(p => p[0]);
        
