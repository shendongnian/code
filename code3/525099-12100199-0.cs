    var b = false;
    foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains("notepad"))
                    {
                        if (!b) b = true;
                    }
                }
                    Console.WriteLine(b);
