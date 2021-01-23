    static Array Split(string source, int start, params char[] args)
    {
        var split = source.Split(args[start]);
        if (args.Length == start + 1)
            return split;
        return split.Select(s => Split(s, start + 1, args)).ToArray();
    }
    ...
    String s = "1:2,a;1:3,b;1:4";
    Array array = Split(s, 0, ';', ':', ',');
