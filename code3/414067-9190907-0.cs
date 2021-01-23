    string[] input = {
                            "A-B-C",
                            "AB-CD",
                            "ABC-D-E",
                            "AB-CD-K"
                        };
    
    var regex = new Regex(@"\w(?=-)|(?<=-)\w", RegexOptions.Compiled);
    
    var result = input.Select(s => string.Concat(regex.Matches(s)
        .Cast<Match>().Select(m => m.Value)));
    
    foreach (var s in result)
    {
        Console.WriteLine(s);
    }
