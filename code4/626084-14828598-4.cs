    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            int counter = 0;
            string currentProcess = "";
            List<int> processes = new List<int>();
            Process compiler = new Process();
            compiler.StartInfo.FileName = @"c:\YourPath\Handle.exe";
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            while ((line = compiler.StandardOutput.ReadLine()) != null)
            {
                // skipping applicaion info
                if (++counter > 6)
                {
                    if (!" -".Contains(char.Parse(line.Substring(0, 1))))
                    {
                        currentProcess = line;
                    }
                    else if ((new[] { ".avi", ".mkv", ".mpg", ".mp4", ".wmv" })
                        .Contains(line.ToLower().Substring(line.Length - 4)))
                    {
                        int pos = currentProcess.IndexOf("pid:") + 5;
                        string pid = currentProcess.Substring(pos, currentProcess.IndexOf(" ", pos) - pos);
                        processes.Add(Int32.Parse(pid));
                    }
                }
            }
            compiler.WaitForExit();
            
            // enumerate the processes
            foreach (int pid in processes.Distinct())
            {
                var process = Process.GetProcesses().Where(i => i.Id == pid).FirstOrDefault();
                Console.WriteLine("{0} ({1})", process.ProcessName, process.Id);
            }
            Console.ReadLine();
        }
    }
