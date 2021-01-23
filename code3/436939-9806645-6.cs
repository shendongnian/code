       private void RunAndWait(string app, params string[] args)
       {
           foreach (string arg in args)
           {
               Process proc = new Process
                              {
                                  StartInfo = new ProcessStartInfo(app, arg)
                                                  {
                                                      UseShellExecute = false,
                                                      CreateNoWindow = true
                                                  }
                              };
               proc.Start();
               proc.WaitForExit();
           }
       }
