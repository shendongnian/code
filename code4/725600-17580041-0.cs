    process.StartInfo.UseShellExecute = false; 
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += p_OutputDataReceived;
    process.Start();
    process.BeginOutputReadLine();
    
