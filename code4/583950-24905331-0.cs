    static void Pause(int sec)
        {
            Console.WriteLine();
            var pauseProc = Process.Start(
                new ProcessStartInfo()
                {
                    FileName = "cmd",
                    Arguments = "/C TIMEOUT /t " + sec + " /nobreak > NUL",
                    UseShellExecute = false
                });
            pauseProc.WaitForExit();
        }
