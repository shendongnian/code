    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = 
        new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; // Hides the command prompt window
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = "/C mkdir " + serverpath + @"\Log";
    startInfo.Username = "domain\username";
    startInfo.Password = // SecureString object containing the password
    process.StartInfo = startInfo;
    process.Start();
