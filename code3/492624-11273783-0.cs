        public static void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                var procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                var proc = new System.Diagnostics.Process();
                proc.OutputDataReceived += (s,e) => { Console.WriteLine(e.Data);};
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.BeginOutputReadLine();
            }
            catch (Exception objException)
            {
                Console.WriteLine("Error: " + objException.Message);
                // Log the exception
            }
        }
