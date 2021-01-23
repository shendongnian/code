       private void RunAndWait(string app, string args)
       {
           Process proc = new Process
                          {
                              StartInfo = new ProcessStartInfo(app, args)
                                              {
                                                  UseShellExecute = false,
                                                  CreateNoWindow = true
                                              }
                          };
           proc.Start();
           proc.WaitForExit();
       }
