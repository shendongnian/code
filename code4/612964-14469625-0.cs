    var startInfo = new ProcessStartInfo { FileName = "notepad.exe" };
    var process = new Process();
    process.StartInfo = startInfo;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = false;
    process.Start();
    process.WaitForInputIdle();
    // this line below will always be false because `process.ProcessName will be 
    //notepad and process.StartInfo.FileName = notepade.exe 
    if (process.ProcessName.Equals(process.StartInfo.FileName) == false)
    {
       var theConfiguredProcessName = process.ProcessName;
    }
