            GetWindowThreadProcessId((IntPtr)app.Hwnd, out iProcessId);
            wb.Close(true,Missing.Value,Missing.Value);
            app.Quit();
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (p.Id == iProcessId)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
    }
    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    uint iProcessId = 0;
