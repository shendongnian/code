    {
     Process xyProcess = new Process();
     xyProcess.StartInfo.FileName = "FilenameYouWant";
     xyProcess.StartInfo.UseShellExecute = false;
     xyProcess.StartInfo.CreateNoWindow = true;
     xyProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
     xyProcess.StartInfo.RedirectStandardInput = true;
     xyProcess.StartInfo.RedirectStandardOutput = true;
     xyProcess.StartInfo.RedirectStandardError = true;
     xyProcess.EnableRaisingEvents = true;
     xyProcess.OutputDataReceived += process_DataReceived;
    
     // Start the process
     xyProcess.Start();
     xyProcess.BeginErrorReadLine();
     xyProcess.BeginOutputReadLine();
     xyProcess.WaitForExit();
    
    }
    static private void process_DataReceived(object sender, DataReceivedEventArgs e)
    {
        //Catch the process response here
    }
