    static void Main(string[] args)
    {
        System.Threading.Thread.Sleep(10000);
        ExecuteCommandAndWait("taskkill", "/F /IM \"v*\"");
        ExecuteCommandAndWait("taskkill","/F /IM \"B*\"");
        System.Threading.Thread.Sleep(5000);
        ExecuteCommandAndWait("shutdown", "/f /p");
    }
    
    private static void ExecuteCommandAndWait(string fileName, string arguments)
    {
        Process process = new Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.Start();
        process.WaitForExit();
    }
