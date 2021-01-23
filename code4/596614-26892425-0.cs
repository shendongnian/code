    private static int ExecuteBcdEdit(string arguments, out IList<string> output)
    {
        ProcessStartInfo psi = new ProcessStartInfo(@"C:\Windows\Sysnative\cmd.exe", "/c bcdedit " + arguments) { UseShellExecute = false, RedirectStandardOutput = true };
        var process = new Process { StartInfo = psi };
        process.Start();
        StreamReader outputReader = process.StandardOutput;
        process.WaitForExit();
        output = outputReader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        return process.ExitCode;
    }
