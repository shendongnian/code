     public void ExecuteBatFiles(List<string> path, int time)
        {
            foreach(string location in path)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(location);
                processInfo.UseShellExecute = false;
                Process batchProcess = new Process();
                batchProcess.StartInfo = processInfo;
                batchProcess.Start();
                Thread.Sleep(time);
            }
        }
