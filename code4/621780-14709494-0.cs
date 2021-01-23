    var processes = Process.GetProcessesByName(processName);
    foreach (var process in processes)
    {
        Console.WriteLine("{0} running.", process);
        process.Exited += (sender, e) => Console.WriteLine("{0} exited.", sender);
        process.EnableRaisingEvents = true;
    }
