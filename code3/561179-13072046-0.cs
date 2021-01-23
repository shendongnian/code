                var procStartInfo = new ProcessStartInfo(@"cmd", "/c " + @"ping 127.0.0.1 -n 10")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var proc = new Process { StartInfo = procStartInfo };
                result = await Task<string>.Factory.StartNew(() =>
                {
                    proc.Start();
                    proc.WaitForExit();
                    return proc.StandardOutput.ReadToEnd();
                }, TaskCreationOptions.PreferFairness);
