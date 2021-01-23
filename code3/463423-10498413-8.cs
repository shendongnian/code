    string path = @"d:\AssemblyInfo.cs";
    
    if (File.Exists(path))
    {
        // Open the file to read from.
        string[] readText = File.ReadAllLines(path);
        var versionInfoLines = readText.Where(t => t.Contains("[assembly: AssemblyVersion"));
        foreach (string item in versionInfoLines)
        {
            string version = item.Substring(item.IndexOf('(') + 2, item.LastIndexOf(')') - item.IndexOf('(') - 3);
            Console.WriteLine(version);
        }
    }
