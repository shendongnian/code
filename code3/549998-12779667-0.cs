    System.Diagnostics.Process process = new System.Diagnostics.Process(); 
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
     startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
     startInfo.FileName = "cmd.exe";
     startInfo.Arguments = "ipconfig";
     process.StartInfo = startInfo;
     process.Start(); 
