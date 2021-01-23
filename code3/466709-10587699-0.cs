    Process process = Process.Start("cmd");
    
    if (process != null)
    {
       process.StandardInput.WriteLine("dir");
       process.StandardInput.WriteLine("ping");
       process.StandardInput.WriteLine("something");
    }
