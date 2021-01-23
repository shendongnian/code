    var result = Regex.Matches(File.ReadAllText(fileName), @"\[`Max`(.*?)\]", RegexOptions.Singleline)
                .Cast<Match>()
                .Select(m => m.Groups[1].Value.Split(" \t\n\r".ToArray(), StringSplitOptions.RemoveEmptyEntries))
                .ToList();
    foreach (var v in result)
    {
        Console.WriteLine(String.Join(", ", v));
    }
