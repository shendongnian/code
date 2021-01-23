    Process objProcess = new Process();
    objProcess.StartInfo.UseShellExecute = false;
    objProcess.StartInfo.RedirectStandardOutput = true;
    objProcess.StartInfo.CreateNoWindow = true;
    objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;   
    //file location
    objProcess.StartInfo.FileName = string.Format(@"D:\programs\PreRef\Run.bat";");
    //any argument 
    objProcess.StartInfo.Arguments = string.Format("");
    try
    {
     objProcess.Start();
    }
    catch
    {
     throw new Exception("Error");
    }
    StreamReader strmReader = objProcess.StandardOutput;
    string strTempRow = string.Empty;
    while ((strTempRow = strmReader.ReadLine()) != null)
    {
        Console.WriteLine(strTempRow);
    }
    if (!objProcess.HasExited)
    {
       objProcess.Kill();
    }
