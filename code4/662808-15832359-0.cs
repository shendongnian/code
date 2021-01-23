    bool exists = false;
    string output = "";
    string error = "";
    
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process = new System.Diagnostics.Process();
                ExecuteShellCommand(process, "NET USE", "\""+ @path + "\" "+
                   this.password+ " /USER:"+machinename+"\\"+username + " /PERSISTENT:NO",
                   ref output, ref error);
    Console.WriteLine("\r\n\t__________________________"+
                    "\r\n\tOutput:" + output.Trim().Replace("\r", " ") +
                    "\r\n\tError: " + error.Trim().Replace("\r"," "));
    
                if (output.Length>0 && error.Length==0)
                {
                    exists = true;
                }
    
                process = new System.Diagnostics.Process();
                ExecuteShellCommand(process, "NET USE", " /DELETE " + @path,
                    ref output, ref error);
....
    public void ExecuteShellCommand(System.Diagnostics.Process process, string fileToExecute,
            string command, ref string output, ref string error)
        {
            try
            {
                string CMD = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"{0}\cmd.exe", new object[] { Environment.SystemDirectory });
                string args = string.Format(System.Globalization.CultureInfo.InvariantCulture, "/C {0}", new object[] { fileToExecute });
                if (command != null && command.Length > 0)
                {
                    args += string.Format(System.Globalization.CultureInfo.InvariantCulture, " {0}", new object[] { command, System.Globalization.CultureInfo.InvariantCulture });
                }
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(CMD, args);
                
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                process.StartInfo = startInfo;
                process.Start();
                // timeout
	process.WaitForExit(10 * 1000);
	output = process.StandardOutput.ReadToEnd();
                 error = process.StandardError.ReadToEnd();
            }
            catch (Win32Exception e32)
            {
                Console.WriteLine("Win32 Exception caught in process: {0}", e32.ToString());
            }
            catch (Exception e
            {
                Console.WriteLine("Exception caught in process: {0}", e.ToString());
            }
            finally
            {
                // close process and do cleanup
                process.Close();
                process.Dispose();
                process = null;
            }
        }
