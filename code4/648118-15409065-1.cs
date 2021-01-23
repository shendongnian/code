    static IEnumerable<string> OddLines(string path)
    {
        var flipper = true;
        foreach (var line in File.ReadAllLines(path))
        {
            if (flipper) yield return line;
            flipper = !flipper;
        }
    }
