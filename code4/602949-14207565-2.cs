    System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
            foreach (Process P in myProcesses)
            {
                if (P.MainWindowTitle.Length > 1)
                {
                    Console.WriteLine(P.ProcessName + ".exe");
                    Console.WriteLine(" " + P.MainWindowTitle);
                    Console.WriteLine("");
                }
            }
