    static void Main(string[] args)
    {
        var procs = Process.GetProcesses();
        foreach (var proc in procs) {
            TimeSpan runtime;
            try {
                runtime = DateTime.Now - proc.StartTime;
            }
            catch (Win32Exception ex) {
                // Ignore processes that give "access denied" error.
                if (ex.NativeErrorCode == 5)
                    continue;   
                throw;
            }
            Console.WriteLine("{0}  {1}", proc, runtime);
        }
        Console.ReadLine();
    }
