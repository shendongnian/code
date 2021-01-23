    var outputText = new StringBuilder();
    var errorText = new StringBuilder();
    string returnvalue;
    using (var process = Process.Start(new ProcessStartInfo(
        "C:\\someapp.exe",
        "some params")
        {
            CreateNoWindow = true,
            ErrorDialog = false,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        }))
    {
        process.OutputDataReceived += (sendingProcess, outLine) =>
            outputText.AppendLine(outLine.Data);
        process.ErrorDataReceived += (sendingProcess, errorLine) =>
            errorText.AppendLine(errorLine.Data);
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
        returnvalue = outputText.ToString() + Environment.NewLine + errorText.ToString();
    }
