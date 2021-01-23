    class Curl
    {
        internal static List<ProcessObject> _processes = new List<ProcessObject>();
    
        // ....
    
        private static void oProcess_Exited(object sender, EventArgs e)
        {
            var p = sender as Process;
            if (p != null && _processes.Contains(p))
               _processes.Remove(p);
    
            _counter++;
            if (_counter == 1000)
            {
                MessageBox.Show("here");
            }
        }
    
        public ProcessObject(string _arg, string _curl)
        {
            oStartInfo.FileName = _curl;
            oStartInfo.Arguments = _arg;
            oStartInfo.UseShellExecute = false;
            oProcess.EnableRaisingEvents = true;
            oProcess.Exited += new EventHandler(oProcess_Exited);
            oProcess = Process.Start(oStartInfo);
            Curl._processes.Add(oProcess);
        }
    }
