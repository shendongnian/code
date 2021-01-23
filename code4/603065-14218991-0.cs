    using System;
    using System.Diagnostics;
    using System.IO;
    
    class MainClass
    {
        static void Main(string[] args)
        {
            int pid = Process.GetCurrentProcess().Id;
            DirectoryInfo taskDir = new DirectoryInfo(String.Format("/proc/{0}/task", pid));
            foreach(DirectoryInfo threadDir in taskDir.GetDirectories())
            {
                int tid = Int32.Parse(threadDir.Name);
                Console.WriteLine(tid);
            }
        }
    }
