    private static int Get1(string myBaseDirectory)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(myBaseDirectory);
        return dirInfo.EnumerateDirectories()
                   .AsParallel()
                   .SelectMany(di => di.EnumerateFiles("*.*", SearchOption.AllDirectories))
                   .Count() + dirInfo.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Count();
    }
