    var eol = new[] { '\r', '\n' };
    var pos = 0;
    while (pos < input.Length)
    {
        var i = input.IndexOfAny(eol, pos);
        if (i < 0)
        {
            i = input.Length;
        }
        if (i != pos)
        {
            var line = input.Substring(pos, i - pos);
            // process line
        }
        pos = i + 1;
    }
