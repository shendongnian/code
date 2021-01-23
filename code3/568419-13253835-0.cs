    using (var process = new Process())
    {
        var startInfo = process.StartInfo;
        startInfo.FileName = "sc";
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        // tell Windows that the service should restart if it fails
        startInfo.Arguments = string.Format("failure \"{0}\" reset= 0 actions= restart/60000", serviceName);
        process.Start();
        process.WaitForExit();
        exitCode = process.ExitCode;
        process.Close();
    }
