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
        //We must write "a" to the other program before we wait for a answer or we will be waiting forever.
        standardInput.WriteLine("a"); //New Line
        while ((line = standardOutput.ReadLine()) != null)
        {
            Console.WriteLine(line);
            
            //You can replace "a" with `Console.ReadLine()` if you want to pass on the console input instead of sending "a" every time.
            standardInput.WriteLine("a"); //New Line
        }
