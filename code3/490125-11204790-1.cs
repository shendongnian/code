        private static void Run()
        {
            var processes = CreateBatchOfProcesses("execute.bat", "executeN.bat", "executeHD.bat", "executeFHD.bat");
            foreach (Process p in processes)
            {
                p.Start();
                p.WaitForExit();
                // Do other stuff with the process.
            }
        }
        private static List<Process> CreateBatchOfProcesses(params string[] paths)
        {
            var batch = new List<Process>(paths.Length);
            foreach (string path in paths)
            {
                string mappedPath = Server.MapPath(String.Concat(".\\", path));
                ProcessStartInfo info = new ProcessStartInfo(mappedPath);
                info.UseShellExecute = false;
                Process process = new Process();
                process.StartInfo = info;
                batch.Add(process);
            }
            return batch;
        }
