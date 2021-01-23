    using System;
    using System.Runtime.InteropServices;  
    namespace ExcelSupport
    {
        public class ExcelController : IDisposable
        {
            private Microsoft.Office.Interop.Excel.Application _ExcelApplication;
            private bool disposedValue = false;   // To detect redundant calls
            private string _caption; //used to uniquely identify hidden Excel instance
            //
            // Windows API used to help close Excel instance
            //
            [DllImport("user32.dll")] 
            private static extern int EndTask(IntPtr hWnd);
            [DllImport("user32.dll")]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
            [DllImport("kernel32.dll")] 
            private static extern IntPtr SetLastError(int dwErrCode);
        public ExcelController()
        {
            OpenExcel(null);
        }
        public ExcelController(string workbookName)
        {
            OpenExcel(workbookName);
        }
        private void OpenExcel(string workbookName)
        {
            _ExcelApplication = new Microsoft.Office.Interop.Excel.Application();
            _caption = System.Guid.NewGuid().ToString().ToUpper();
            _ExcelApplication.Caption = _caption;
            _ExcelApplication.Visible = false;
            _ExcelApplication.DisplayAlerts = false;
            if(workbookName != null)
                _ExcelApplication.Workbooks.Open(workbookName);
        }
        public Microsoft.Office.Interop.Excel.Application Application
        {
            get { return _ExcelApplication; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                try
                {
                    if (_ExcelApplication != null)
                    {
                        foreach (Microsoft.Office.Interop.Excel.Workbook WorkBookName in _ExcelApplication.Workbooks)
                        {
                            WorkBookName.Close(false);
                        }
                        IntPtr iHandle = IntPtr.Zero;
                        iHandle = new IntPtr(_ExcelApplication.Parent.Hwnd);
                        _ExcelApplication.DisplayAlerts = false;
                        _ExcelApplication.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApplication);
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_ExcelApplication);
                        SetLastError(0);
                        if (IntPtr.Equals(iHandle, IntPtr.Zero))
                            iHandle = FindWindow(null, _caption);
                        if (!IntPtr.Equals(iHandle, IntPtr.Zero))
                        {
                            int iRes;
                            uint iProcId;
                            iRes = (int)GetWindowThreadProcessId(iHandle, out iProcId);
                            if (iProcId == 0)
                            {
                                if (EndTask(iHandle) == 0)
                                    throw new ApplicationException("Excel Instance Could Not Be Closed");
                            }
                            else
                            {
                                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById((int)iProcId);
                                proc.CloseMainWindow();
                                proc.Refresh();
                                if (!proc.HasExited)
                                    proc.Kill();
                            }
                        }
                    }
                }
                finally
                {
                    _ExcelApplication = null;
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
            this.disposedValue = true;
        }
    }
