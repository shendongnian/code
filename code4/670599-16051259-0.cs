    Process[] processes = Process.GetProcesses();
    
        foreach(Process process in processes) {
        Console.WriteLine("PID:  " + process.Id);
        Console.WriteLine("Name: " + process.Name);
        Console.WriteLine("Modules:");
        foreach(ProcessModule module in process.Modules) {
            Console.WriteLine(module.FileName);
        }
