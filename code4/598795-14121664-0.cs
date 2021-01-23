    private static const string BasePath = @"c:\windows\assembly";
    public static bool HasDotNetFullversion()
    {
        var gacFolders = new List<string>()
        {
            "GAC", "GAC_32", "GAC_64", "GAC_MSIL",
            "NativeImages_v2.0.50727_32", "NativeImages_v2.0.50727_64"
        };
        var assemblyFolders = from gacFolder in gacFolders
                              let path = Path.Combine(BasePath, gacFolder)
                              where Directory.Exists(path)
                              from directory in Directory.GetDirectories(path)
                              select directory;
        var hasSystemWeb = assemblyFolders.Any(x =>
            x.EndsWith("system.web", StringComparison.InvariantCultureIgnoreCase));
    }
