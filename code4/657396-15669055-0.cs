    var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "path-to-file.bat"
                }
            };
            process.Start();
            process.WaitForExit();
