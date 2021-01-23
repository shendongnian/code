     string sCurrentPAth =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    Process.Start("D:\\");
    const string P1 = "D:\\";
    const string P2 = "D:\\Dir";
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.CreateNoWindow = false;
    startInfo.UseShellExecute = false;
    startInfo.FileName = "MyExe.exe";
    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    startInfo.Arguments = "-f j -o \"" + P1 + "\" -z 1.0 -s y " + P2;
    try
    {
        
        using (Process exeProcess = Process.Start(startInfo))
        {
        exeProcess.WaitForExit();
        }
    }
    catch
    {
        // Log error.
    }
    }
