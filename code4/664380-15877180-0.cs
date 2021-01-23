    ProcessStartInfo processStartInfo = 
      new ProcessStartInfo(executableName, executableParameter);
    processStartInfo.UseShellExecute = false;
    processStartInfo.ErrorDialog = false;
    processStartInfo.RedirectStandardError = true;
    processStartInfo.RedirectStandardInput = true;
    processStartInfo.RedirectStandardOutput = true;
    Process process = new Process();
    process.StartInfo = processStartInfo;
    bool processStarted = process.Start();
    StreamWriter inputWriter = process.StandardInput;
    StreamReader outputReader = process.StandardOutput;
    StreamReader errorReader = process.StandardError;
    //Write and read process console using inputWriter and outputReader.
    process.WaitForExit();
