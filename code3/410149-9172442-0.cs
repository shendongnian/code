    using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
    {
        proc.StartInfo.FileName = "testrunner.bat";
        proc.StartInfo.Arguments = "blah blah blah";
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.UseShellExecute = false;
        proc.Start();
        outputMessage = proc.StandardOutput.ReadToEnd();
        logFile = File.AppendText("D:\\temp\\SoapUITest.log");
        logFile.AutoFlush = true;
        logFile.Write(outputMessage);
        logFile.Close();
    }
