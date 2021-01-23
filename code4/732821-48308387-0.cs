     if (excelApp != null)
                {
                    int excelProcessId = -1;
                    GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), ref excelProcessId);
                    Process ExcelProc = Process.GetProcessById(excelProcessId);
                    if (ExcelProc != null)
                    {
                        ExcelProc.Kill();
                    }
                }
 
