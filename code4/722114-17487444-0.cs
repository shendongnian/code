    string line = "Duration: 00:00:02.60, start: 0.000000, bitrate: 517 kb/s";
    string pattern = "bitrate: ";
    int bitrate = -1;
    int index = line.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);
    if(index >= 0)
    {
        index += pattern.Length;
        int endIndex = line.IndexOf(" kb/s", index + 1, StringComparison.OrdinalIgnoreCase);
        if(endIndex >= 0)
        {
            int.TryParse(line.Substring(index, endIndex - index), out bitrate);
        }
    }
