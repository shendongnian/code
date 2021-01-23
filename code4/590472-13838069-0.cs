    Process process = new Process();
        process.StartInfo.FileName = "Notepad";
        process.Start();
    
        process.WaitForInputIdle();
    
        Thread.Sleep(5000);
        if(!process.CloseMainWindow())
        {
            process.Kill();
        }
