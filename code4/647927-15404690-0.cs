    var process = System.Diagnostics.Process.GetProcessesByName("MyProcess").FirstOrDefault();
    
    var process = System.Diagnostics.Process.GetProcesses().FirstOrDefault(p => p.Modules[0].ModuleName == "MyModule");
    var process = Process.GetProcesses().FirstOrDefault(p => p.MainWindowTitle == "NotePad");
    if (process != null)
    {
        SetWindowPos(process.MainWindowHandle);
    }
