    IntPtr xAsIntPtr = new IntPtr(excelObj.Application.Hwnd);
    excelObj.ActiveWorkbook.Close();
    
    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                    foreach (System.Diagnostics.Process p in process)
                    {
                        if (p.MainWindowHandle == xAsIntPtr)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                        }
                    }
