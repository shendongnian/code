    string longTermDirectory = Properties.Settings.Default.LongTermDirectory;
    DirectoryInfo dir = new DirectoryInfo(longTermDirectory);
    dir.Create(); // does nothing if it already exists
    int Number = int.MinValue;
    DirectoryInfo latestFolder = dir.EnumerateDirectories("*.*", SearchOption.AllDirectories)
        .Where(d => int.TryParse(d.Name, out Number))
        .Select(Directory => new { Directory, Number })
        .OrderByDescending(x => x.Number)
        .Select(x => x.Directory)
        .First();
