    private static void AttachToConsole ()
    {
        System.Diagnostics.Process process = null;
        process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        //process.StartInfo.RedirectStandardInput = true;
        //process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.CreateNoWindow = false;
        process.EnableRaisingEvents = true;
        process.Start();
        process.OutputDataReceived += null;
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        process.OutputDataReceived -= null;
        process.CloseMainWindow();
        process.Close();
    }
