    System.Diagnostics.Process clientProcess = new Process();
    clientProcess.StartInfo.FileName = "java";
    clientProcess.StartInfo.Arguments = @"-jar "+ jarPath +" " + argumentsFortheJarFile;
    clientProcess.Start();
    clientProcess.WaitForExit();   
    int code = clientProcess.ExitCode;
