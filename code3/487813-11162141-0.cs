    public static bool Build(string command, out StringBuilder buildOutput)
            {
                try
                {
                    buildOutput = new StringBuilder();
                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
                    startInfo.Arguments = "/C " + " nasm " + command;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    Process p = Process.Start(startInfo);
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    if (output.Length != 0)
                        buildOutput.Append(output);
                    else if (error.Length != 0)
                        buildOutput.Append(error);
                    else
                        buildOutput.Append("\n");
                    return true;
                }
                catch
                {
                    buildOutput = null;
                    return false;
                }
            }
