        Process p = new Process();
        var procStartInfo = new ProcessStartInfo(@"ConsoleApplication1.exe") 
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardInput = true, //New Line
        };
        p.StartInfo = procStartInfo;
        p.Start();
        StreamReader standardOutput = p.StandardOutput;
        StreamWriter standardInput = p.StandardInput; //New Line
        var line = string.Empty;
        while ((line = standardOutput.ReadLine()) != null)
        {
            Console.WriteLine(line);
            standardInput.WriteLine("a"); //New Line
        }
