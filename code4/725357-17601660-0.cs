    var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "qwinsta.exe",
                        Arguments = null,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
            }
