    using (StreamReader standardOutput = p.StandardOutput)
    using (StreamWriter standardInput = p.StandardInput)
    {
        var line = string.Empty;
        while ((line = standardOutput.ReadLine()) != null)
        {
            Console.WriteLine(line);
            standardInput.WriteLine("a"); //New Line
        }
    }
