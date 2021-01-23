    static void Main()
    {
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            string output = RunCommand(input);
            Console.WriteLine(output);
        }
    }
    
    static string RunCommand(string command)
    {
        Process p = Process.Start(new ProcessStartInfo()  {
            FileName = "cmd",
            Arguments = "/c \"" + command + "\"",
            RedirectStandardError = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        });
    
        string output = p.StandardOutput.ReadToEnd();
        string error = p.StandardError.ReadToEnd();
        p.WaitForExit();
        return output + error;
    }
