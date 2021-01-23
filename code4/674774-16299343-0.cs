        var startInfo = new ProcessStartInfo {
        //some other parameters here
        ...
        FileName = pathToExe,
        Arguments = String.Format("{0}",someParameters),
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        RedirectStandardInput = true,
        WorkingDirectory = pdfToolPath
        };
        var p = new Process();
        p.StartInfo = startInfo;
        p.Start();
        p.WaitForExit(timeToExit);
        //Read the Error:
        string error = p.StandardError.ReadToEnd();
        //Read the Output:
        string output = p.StandardOutput.ReadToEnd();
