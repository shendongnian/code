    class Program
    {
        static void Main(string[] args)
        {
            var processes = GetProcesses();
            
            // enumerate the processes
            foreach (Tuple<int,string> mediaFile in processes.Distinct())
            {
                var process = Process.GetProcesses().Where(i => i.Id == mediaFile.Item1).FirstOrDefault();
                Console.WriteLine("{0} ({1}) uses {2}", process.ProcessName, process.Id, mediaFile.Item2);
            }
            Console.ReadLine();
        }
        private static List<Tuple<int,string>> GetProcesses()
        {
            string line = "";
            int counter = 0;
            string currentProcess = "";
            List<Tuple<int, string>> mediaFiles = new List<Tuple<int, string>>();
            Process compiler = new Process();
            compiler.StartInfo.FileName = @"c:\YourPath\Handle.exe";
            compiler.StartInfo.CreateNoWindow = true;
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
                        mediaFiles.Add(new Tuple<int, string>(Int32.Parse(pid),line.Substring(21)));
                    }
                }
            }
            compiler.WaitForExit();
            return mediaFiles;
        }
    }
