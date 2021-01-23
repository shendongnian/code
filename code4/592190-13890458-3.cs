    List<string> list = new List<string>()
    {
        "Test 0 Length 32 [41 - 73]",
        "Test 1 Length 22 [81 - 103]"
    };
    var numbers = list.SelectMany(x => Regex.Matches(x, @"\[(\d+)[ -]+(\d+)\]")
                                       .Cast<Match>()
                                       .SelectMany(m =>
                                        {
                                           var start = int.Parse(m.Groups[1].Value);
                                           var end = int.Parse(m.Groups[2].Value);
                                           return Enumerable.Range(start, end - start + 1);                                                         
                                        })
                                    )
                        .ToList();
