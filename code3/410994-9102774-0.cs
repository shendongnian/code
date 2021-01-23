            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", 
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            try
            {
                Process _proc;
                using (_proc = Process.Start(startInfo))
                {
                    _proc.EnableRaisingEvents = true;
                    _proc.BeginErrorReadLine();
                    _proc.BeginOutputReadLine();
                    var myStreamWriter = _proc.StandardInput;
                    myStreamWriter.WriteLine("D:\\your.exe"); //write your.exe to cmd and press enter :) 
                    _proc.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
