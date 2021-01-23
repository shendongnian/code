    try
    {
        Process proc = Process.GetCurrentProcess();
        string strProcName = proc.ProcessName;
        Console.WriteLine("Process: " + strProcName);
    
        using (PerformanceCounter total_cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total", true))
        {
            using (PerformanceCounter process_cpu = new PerformanceCounter("Process", "% Processor Time", strProcName, true))
            {
                for (; ; )
                {
                    Console.CursorTop = 1;
                    Console.CursorLeft = 0;
    
                    float t = total_cpu.NextValue() ;
                    float p = process_cpu.NextValue();
                    Console.WriteLine(String.Format("Total CPU (%) = {0}\t\t\nApp CPU (%) = {1}\t\t\nApp RAM (KB) = {2}",
                        t, p, Process.GetCurrentProcess().WorkingSet64 / (1024)
                        ));
    
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("Exception: " + ex);
    }
