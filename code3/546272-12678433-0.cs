    using System;
    using System.Diagnostics;
    using System.Threading;
    
    class Program
    {
        public static void Main()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c " + "type Test.cs")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            
            Process process = Process.Start(startInfo);
            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.BeginOutputReadLine();
            process.Start();
            process.WaitForExit();
            // We may not have received all the events yet!
            Thread.Sleep(5000);
        }
    }
