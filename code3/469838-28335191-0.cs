    public static void Extract(string zipPath, string extractPath)
    {
        try
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Path.GetFullPath(@"7za.exe"),
                Arguments = "x \"" + zipPath + "\" -o\"" + extractPath + "\""
            };
            Process process = Process.Start(processStartInfo);
            process.WaitForExit();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error extracting {0}: {1}", extractPath, e.Message);
            throw;
        }
    }
