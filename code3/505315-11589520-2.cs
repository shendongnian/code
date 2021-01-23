    static void ParseLine(
        string line,
        int keyIndex,
        int keyLength,
        Action<List<byte>> txHandler,
        Action<List<byte>> rxHandler)
    {
        var start = line.IndexOf('[');
        var end = line.IndexOf(']', start);
        var mode = line.Substring(start + 1, end - start - 1);
        var values = line.Substring(end + 1)
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(keyIndex)
            .Take(keyLength)
            .Select(s => Convert.ToByte(s, 16))
            .ToList();
        if (mode == "TX") txHandler(values);
        else if (mode == "RX") rxHandler(values);
    }
