    var input = "<a href=\"#\" class=\"main\">Getty Center, Restaurant at the</a>";
    var regex = new Regex(@"<a[^>]*>(?<content>.*?)</a[^>]*>",
                          RegexOptions.Singleline);
    var match = regex.Match(input);
    while (match.Success) {
        var group = match.Groups["content"];
        input = input.Substring(0, group.Index)
                + group.Value.Replace(",", "")
                + input.Substring(group.Index + group.Length);
        match = regex.Match(input, group.Index);
    };
