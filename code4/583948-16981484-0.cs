    static void Pause()
    {
        Console.WriteLine();
        var pauseProc = Process.Start(
            new ProcessStartInfo()
                {
                    FileName = "cmd",
                    Arguments = "/C pause",
                    UseShellExecute = false
                });
        pauseProc.WaitForExit();
    }
