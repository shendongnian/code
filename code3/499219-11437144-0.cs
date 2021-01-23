            static void Main(string[] args)
            {
                List<string> ul = new List<string>();
 
                foreach (Process proc in Process.GetProcesses())
                {
                    ul.Add(proc.ProcessName);
                }
            }
