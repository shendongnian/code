    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
    psi.CreateNoWindow = true;
    psi.UseShellExecute = false;
    psi.RedirectStandardInput = true;
    psi.RedirectStandardOutput = true;
    psi.RedirectStandardError = true;
    psi.WorkingDirectory = "Path of the Executable";
        
    System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);
        
    string sCommandLine = string.Format("YourExecutable.exe -{1}", YourParameterValues);
        
    process.StandardInput.WriteLine(sCommandLine);
    process.StandardInput.Flush();
    process.StandardInput.Close();
    process.WaitForExit();
    process.Close();
