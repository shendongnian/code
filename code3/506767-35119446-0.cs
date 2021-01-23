    string command = cmdpath + " " + cmdargs;
    tabc_results.SelectTab(1); 
    DoConsole("\r\nCmd>> " + command + "\r\n");
    var processInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + command);
    processInfo.CreateNoWindow = true;
    processInfo.UseShellExecute = false;
    processInfo.RedirectStandardError = true;
    processInfo.RedirectStandardOutput = true;
    var process = System.Diagnostics.Process.Start(processInfo);
    process.OutputDataReceived += (object sender, System.Diagnostics.DataReceivedEventArgs e) =>
        DoConsole("stdout>>  " + e.Data + "\r\n");
        //Console.WriteLine("output>>" + e.Data);
    process.BeginOutputReadLine();
    process.ErrorDataReceived += (object sender, System.Diagnostics.DataReceivedEventArgs e) =>
        DoConsole("stderr>>  " + e.Data + "\r\n");
        //Console.WriteLine("error>>" + e.Data);
    process.BeginErrorReadLine();
    process.WaitForExit();
    DoConsole("retcode>> " + process.ExitCode.ToString() + "\r\n");
    //Console.WriteLine("ExitCode: {0}", process.ExitCode);
    process.Close();
}
 
