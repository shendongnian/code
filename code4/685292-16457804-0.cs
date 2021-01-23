    string msg = string.empty
    for (int i = 0; i < 5; i++)
    {
        float cpu = getCPUCOunter();
    
        float memory = getRamCounter();
    
        ulong TotalMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        TotalMemory = TotalMemory / 1024000;
    
         float PhysicalMemory = (TotalMemory - memory) * 100 / TotalMemory;
    
         msg += "CPU Utilization =  " + Math.Round(cpu) + "%\r\n" + Environment.NewLine + " \nPhysical Memory Utilization " + Math.Round(PhysicalMemory) + "%" + Environment.NewLine + " at " + DateTime.Now.ToString("HH:mm:ss tt") + Environment.Newline;
         Thread.Sleep(10000);
    }
    
    SendMail("PROD Server CPU and Physical Memory Utalization", msg)
