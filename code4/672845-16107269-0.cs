    string words = "go bread John yesterday going is music musics";
    List<string> wordroots = words.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
    var rootcount = wordroots
        .Select(wr =>
        {
            if (wr.EndsWith("s"))
                wr = wr.Substring(0, wr.Length - 1);
            return wr;
        })
        .GroupBy(g => g);
    foreach (var group in rootcount)
        Console.WriteLine(string.Format("Found word: {0} {1} times.", group.Key, group.Count()));   
