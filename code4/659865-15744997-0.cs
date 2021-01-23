    Process objProcess = new Process();            
    objProcess.StartInfo.UseShellExecute = false;
    objProcess.StartInfo.RedirectStandardOutput = true;
    objProcess.StartInfo.CreateNoWindow = true;
    objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    // Passing the batch file/exe name
    objProcess.StartInfo.FileName = string.Format(strBatchFileName);
    
    // Passing the argument
    objProcess.StartInfo.Arguments = string.Format(strArgument);
    try
    {
     objProcess.Start();
    }
    catch
    {
     throw new Exception("Batch file is not found for processing");
    }
