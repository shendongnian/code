    using System;
    using System.Diagnostics;
    using System.IO;
    
    class Test
    {    
        static void Main()
        {
            ProcessStartInfo procInfo = new ProcessStartInfo
            {
                WorkingDirectory = Path.GetPathRoot(Environment.SystemDirectory),
                FileName = Path.Combine(Environment.SystemDirectory, "netsh.exe"),
                Arguments = "wlan start hostednetwork",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            
            Process proc = Process.Start(procInfo);
            proc.WaitForExit();
        }
    }
