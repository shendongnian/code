    public void Computer_Shutdown()
            {
                if (this.checkBox.Checked)
                {
                    System.Diagnostics.Process[] processes = 
                       System.Diagnostics.Process.GetProcesses();
    
                    foreach (System.Diagnostics.Process 
                               processParent in processes)
                    {
                        System.Diagnostics.Process[] processNames = 
                                     System.Diagnostics.Process.
                                     GetProcessesByName
                                     (processParent.ProcessName);
        
                        foreach (System.Diagnostics.Process 
                                processChild in processNames)
                        {
                            try
                            {
                                System.IntPtr hWnd = 
                                       processChild.MainWindowHandle;
                                
                                if (IsIconic(hWnd))
                                {
                                    ShowWindowAsync(hWnd, SW_RESTORE);
                                }
                        
                                SetForegroundWindow(hWnd);
                                
                                if (!(processChild.
                                   MainWindowTitle.Equals(this.Text)))
                                {
                                    processChild.CloseMainWindow();
                                    processChild.Kill();
                                    processChild.WaitForExit();
                                }
                            }
                            catch (System.Exception exception)
                            {
    
                            }
                        }
                    }
                }
