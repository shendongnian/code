    using System;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var output = "";
            var p = new Process();
            var psi = new ProcessStartInfo("wevtutil.exe", "el");
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            p.StartInfo = psi;
            p.Start();
            using (var processOutput = p.StandardOutput)
            {
                output = processOutput.ReadToEnd();
            }
            p.WaitForExit();
            var eventLogs = output
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            foreach (var item in eventLogs)
            {
                Console.WriteLine(item);
            }
        }
    }
