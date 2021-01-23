    public static void Extract(string zipPath, string extractPath)
    {
        try
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Path.GetFullPath(@"7za.exe"),
                Arguments = "x \"" + zipPath + "\" -o \"" + extractPath + "\""
            };
            Process process = Process.Start(processStartInfo);
            process.WaitForExit();
            if (process.ExitCode != 0) 
            {
                Console.WriteLine("Error extracting {0}.", extractPath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error extracting {0}: {1}", extractPath, e.Message);
            throw;
        }
    }
