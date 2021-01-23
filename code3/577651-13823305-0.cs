        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        /// <summary> Tries to find and kill process by hWnd to the main window of the process.</summary>
        /// <param name="hWnd">Handle to the main window of the process.</param>
        /// <returns>True if process was found and killed. False if process was not found by hWnd or if it could not be killed.</returns>
        public static bool TryKillProcessByMainWindowHwnd(int hWnd)
        {
            uint processID;
            GetWindowThreadProcessId((IntPtr)hWnd, out processID);
            if (processID == 0) return false;
            try
            {
                Process.GetProcessById((int)processID).Kill();
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }            
            return true;
        }
        static void ParseFile(string file)
        {
            try
            {
                log("parsing:" + file);
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(file);
                Excel.Worksheet ws = wb.Worksheets[1];
                //do some stuff here
                wb.Close(false);
                int hWnd = excel.Application.Hwnd;
                excel.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(ws);
                Marshal.FinalReleaseComObject(wb);
                Marshal.FinalReleaseComObject(excel);                
                excel = null;
                ws = null;
                wb = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                TryKillProcessByMainWindowHwnd(hWnd);
            }
            catch (Exception ex)
            {
                log(ex.Message);
            }            
        }
