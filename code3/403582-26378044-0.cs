                        foreach (var process in processes)
                        {
                            try
                            {
                                if (process.MainWindowHandle == new IntPtr(app.WindowHandle32))
                                    visioProcess = process;
                            }
                            catch
                            {
                            }
                        }
                        visioProcess.EnableRaisingEvents = true;
                        visioProcess.Exited += new EventHandler(visioProcess_Exited);
