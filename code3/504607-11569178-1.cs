    Process process = new Process();
    List<string> fullstring = new List<string>();
    
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardInput = true;
    process.StartInfo.UseShellExecute = false;
    process.OutputDataReceived += (sender, args2) => fullstring.Add(args2.Data);
    
    process.Start();
    
    process.StandardInput.WriteLine(@"dir /b /s c:\temp | find """" /v");
    process.BeginOutputReadLine();
    
    process.WaitForExit(10000); //or whatever is appropriate time
    
    process.Close();
