    public static IEnumerable<string> RunCommands(params string[] commands) {
        var process = new Process {
            StartInfo = new ProcessStartInfo("cmd") {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = "/k",
            }
        };
    
        process.Start();
    
        const string prompt = "--Prompt_C2BCE8F8E2C24403A71CA4B7F7521F5B_F659E9F3F8574A72BE92206596C423D5 ";
    
        // replacing standard prompt in order to determine end of command output
        process.StandardInput.WriteLine("prompt " + prompt);
        process.StandardInput.Flush();
        process.StandardOutput.ReadLine();
        process.StandardOutput.ReadLine();
    
        var result = new List<string>();
    
        try {
            var commandResult = new StringBuilder();
    
            foreach (var command in commands) {
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine();
                process.StandardInput.Flush();
    
                process.StandardOutput.ReadLine();
    
                while (true) {
                    var line = process.StandardOutput.ReadLine();
    
                    if (line == prompt) // end of command output
                        break;
    
                    commandResult.AppendLine(line);
                }
    
                result.Add(commandResult.ToString());
    
                commandResult.Clear();
    
            }
        } finally {
            process.Kill();
        }
    
        return result;
    }
