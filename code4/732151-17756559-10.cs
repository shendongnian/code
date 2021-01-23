    static void Main(string[] args)
    {
        Console.Title = "File Enumeration Performance Comparison";
        Stopwatch watch = new Stopwatch();
        watch.Start();
    
        var allfiles = GetPast60("C:\\Users\\UserName\\Documents");
        watch.Stop();
        Console.WriteLine("Total time to enumerate using WINAPI =" + watch.ElapsedMilliseconds + "ms.");
        Console.WriteLine("File Count: " + allfiles);
    
        Stopwatch watch1 = new Stopwatch();
        watch1.Start();
    
        var allfiles1 = GetPast60Enum("C:\\Users\\UserName\\Documents\\");
        watch1.Stop();
        Console.WriteLine("Total time to enumerate using EnumerateFiles =" + watch1.ElapsedMilliseconds + "ms.");
        Console.WriteLine("File Count: " + allfiles1);
    
        Stopwatch watch2 = new Stopwatch();
        watch2.Start();
    
        var allfiles2 = Get1("C:\\Users\\UserName\\Documents\\");
        watch2.Stop();
        Console.WriteLine("Total time to enumerate using Get1 =" + watch2.ElapsedMilliseconds + "ms.");
        Console.WriteLine("File Count: " + allfiles2);
    
    
        Stopwatch watch3 = new Stopwatch();
        watch3.Start();
    
        var allfiles3 = Get2("C:\\Users\\UserName\\Documents\\");
        watch3.Stop();
        Console.WriteLine("Total time to enumerate using Get2 =" + watch3.ElapsedMilliseconds + "ms.");
        Console.WriteLine("File Count: " + allfiles3);
    
        Stopwatch watch4 = new Stopwatch();
        watch4.Start();
    
        var allfiles4 = RunCommand(@"dir /a: /b /s C:\Users\UserName\Documents");
        watch4.Stop();
        Console.WriteLine("Total time to enumerate using Command Prompt =" + watch4.ElapsedMilliseconds + "ms.");
        Console.WriteLine("File Count: " + allfiles4);
    
    
        Console.WriteLine("Press Any Key to Continue...");
        Console.ReadLine();
    }
    
    private static int RunCommand(string command)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo("cmd")
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = String.Format("/c \"{0}\"", command),
            }
        };
        int count = 0;
        process.OutputDataReceived += delegate { count++; };
        process.Start();
        process.BeginOutputReadLine();
    
        process.WaitForExit();
        return count;
    }
    
    static int GetPast60Enum(string dir)
    {
        return new DirectoryInfo(dir).EnumerateFiles("*.*", SearchOption.AllDirectories).Count();
    }
    
    private static int Get2(string myBaseDirectory)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(myBaseDirectory);
        return dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                   .AsParallel().Count();
    }
    
    private static int Get1(string myBaseDirectory)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(myBaseDirectory);
        return dirInfo.EnumerateDirectories()
                   .AsParallel()
                   .SelectMany(di => di.EnumerateFiles("*.*", SearchOption.AllDirectories))
                   .Count();
    }
    
    private static int GetPast60(string dir)
    {
        return FastDirectoryEnumerator.GetFiles(dir, "*.*", SearchOption.AllDirectories).Length;
    }
