    private void RunBatch(CmdObj obj)
    {
        var process = new Process();
        var startInfo = new ProcessStartInfo
        {
            FileName = obj.SrcFile,
            WindowStyle = ProcessWindowStyle.Normal,
            CreateNoWindow = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true, //This is required if we want to get the output
            RedirectStandardError = true,
            UseShellExecute = false
        };
    
    
        try
        {
            if (!obj.SrcFile.ToLower().Trim().EndsWith(".bat"))
            throw new FileLoadException("Not a valid .bat file",obj.SrcFile);
        
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        
            obj.Activity = process.StandardOutput.ReadToEnd(); //Get the output from the target process
            obj.Error = process.StandardError.ReadToEnd();
            
        }
        catch (Exception ex)
        {
            obj.Exception = ex;
        }
        finally
        {
            process.Close(); //Terminate the process after getting what is required
        }
    }
