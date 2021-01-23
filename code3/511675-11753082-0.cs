     private void StartProcess()
    {
        Process service = new Process();
        var pi = new ProcessStartInfo(exePath, null);
        pi.UseShellExecute = false;        
        service.StartInfo = pi;
        //start the process
        service.Start();
    }
    ...
    Thread t = new Thread(StartProcess);
    t.Start();
