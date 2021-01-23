            private void Application_Startup(object sender, StartupEventArgs e)
            {
                try
                {
                    if (e.Args.Length > 0)
                    {
                        foreach (string arg in e.Args)
                        {
                            if (arg == "-restart")
                            {
                                // WaitForConnection.exe
                                foreach (Process p in Process.GetProcesses())
                                {
                                    // In case we get Access Denied
                                    try
                                    {
                                        if (p.MainModule.FileName.ToLower().EndsWith("yourapp.exe"))
                                        {
                                            p.Kill();
                                            p.WaitForExit();
                                            break;
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
