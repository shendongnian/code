    using (Process process = new Process())
    {
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = @"C:\Program Files\Blacksmith\bin\apache\bin\httpd.exe";
    
        // Redirects the standard input so that commands can be sent to the shell.
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
    
        process.OutputDataReceived += ProcessOutputDataHandler;
        process.ErrorDataReceived += ProcessErrorDataHandler;
    
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    
        process.WaitForExit();
    }
