                try
                {
                    Process p = new Process();
                    // Redirect the error stream of the child process.
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.FileName = Properties.Settings.Default.CompilerPath + @"\tsc.exe";
                    p.StartInfo.Arguments = "\"" + file.FullName + "\"";
                    p.Start();
                    
                    // Do not wait for the child process to exit before
                    // reading to the end of its redirected error stream.
                    // p.WaitForExit();
                    // Read the error stream first and then wait.
                    error += (p.StandardError.ReadToEnd());
                    p.WaitForExit();
                    status.Text = "Compiling: " + file.FullName;
                    if (error.Length > 0)
                    {
                        // Show error form
                        if (!shown)
                        {
                            second = new Error();
                            second.Show(this);
                            shown = true;
                        }
                        else
                            shown = false;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    status.Text = "Compilation failure.";
                }
