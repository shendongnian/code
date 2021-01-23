    public string checkPlatform(string path)
    {
        //new process
        Process process = new Process();
        //required to change the path during hosting.
        string exelocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        process.StartInfo.FileName = exelocation+"\\BitCheck.exe";
        process.StartInfo.Arguments = path;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        int exitCode = process.ExitCode;
        switch (exitCode)
        {
            case 0:
                return "X86";
            case 1:
                return "X64";
            case 2:
                return "ANY";
            case 3:
                return "ERROR";
        }
        return "ERROR";
    }
