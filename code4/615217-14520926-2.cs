    public static void Main(string[] args)
    {
        const string rootDirectory = @"C:\sample";
        Console.WriteLine("Scanning through files...");
        Directory.EnumerateDirectories(rootDirectory)
            .AsParallel()
            .ForAll(f => 
                {
                    var lcid = f.Split('\\').Last();
                    Console.WriteLine(lcid);
                    HBScannner.HBScan(new DirectoryInfo(f));
                });
    }
