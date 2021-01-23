    StreamWriter sw = new StreamWriter("MyBatchFile.bat");
                string command = @"bcp ADatabase.dbo.{0} out {0}.bcp -n -Usa -%1";
                ProcessStartInfo processInfo = null;
                try
                {
                    foreach (string table in tables)
                    {
                        command = string.Format(command, table);
                        sw.WriteLine(command);                                        
                    }
                    sw.Flush();
                    sw.Close();
                    processInfo = new ProcessStartInfo("cmd", "/c MyBatchFile.Bat Ppassword");
                    processInfo.RedirectStandardOutput = true;
                    processInfo.CreateNoWindow = false;
                    Process process = new Process();
                    process.StartInfo = processInfo;
                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
