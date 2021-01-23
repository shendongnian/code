    string test = "\"foo\",\"bar\",\"1\",\"\",\"baz\"";
    string pattern = "\"[^\"]*\"";
    MatchCollection mc = Regex.Matches(test, pattern);
    foreach (var m in mc) {
        Console.WriteLine(m);
    }
