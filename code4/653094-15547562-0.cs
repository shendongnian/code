    static void Main(string[] args)
    {
        var psi = new ProcessStartInfo("cmd.exe")
        {
            RedirectStandardInput = true,
            RedirectStandardOutput = false,
            UseShellExecute = false
        };
            
        var p = new Process { StartInfo = psi };
        p.Start();
        var stdin = p.StandardInput;
        // write a line to the subprocess
        p.StandardInput.WriteLine("dir");
    }
