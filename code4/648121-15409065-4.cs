    static IEnumerable<string> OddLines(string path)
    {
        var flipper = true;
        foreach (var line in File.ReadLines(path))
        {
            if (flipper) yield return line;
            flipper = !flipper;
        }
    }
