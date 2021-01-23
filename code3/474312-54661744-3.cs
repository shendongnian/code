    public static async Task<int> ExecAsync(string command, string args)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = command;
        psi.Arguments = args;
        using (Process proc = Process.Start(psi))
        {
            await proc.WaitForExitAsync();
            return proc.ExitCode;
        }
    }
