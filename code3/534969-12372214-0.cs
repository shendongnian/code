    ProcessStartInfo processStartInfo = new processStartInfo("SomeEXE", "inputfile.txt");
    processStartInfo.UseShellExecute = false;
    processStartInfo.ErrorDialog = false;
    
    // Here is where you grab the output:
    processStartInfo.RedirectStandardOutput = true;
    
    Process process = new Process {
      StartInfo = processStartInfo
    };
    process.Start();
    // Now use streams to capture the output
    StreamReader outputReader = process.StandardOutput;
    
    process.WaitForExit();
