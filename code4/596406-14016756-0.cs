    using (Process process = new Process())
    {
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.WorkingDirectory = @"C:\Program Files\Blacksmith\bin\apache\bin";
        process.StartInfo.FileName = "httpd.exe";
    
        // Redirects the standard input so that commands can be sent to the shell.
        process.StartInfo.RedirectStandardInput = true;
    
        process.OutputDataReceived += ProcessOutputDataHandler;
        process.ErrorDataReceived += ProcessErrorDataHandler;
    
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    
        process.WaitForExit();
    }
