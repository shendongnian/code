    public static void Main(string[] args)
    {
        const string rootDirectory = @"C:\sample";
        Directory.EnumerateDirectories(rootDirectory)
            .AsParallel()
            .ForAll(f => HBScannner.HBScan(new DirectoryInfo(f)));
    }
