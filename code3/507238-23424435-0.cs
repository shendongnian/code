        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);
        /// <summary>
        /// Gets the main excel window.
        /// </summary>
        /// <returns>An ArbitraryWindow that represents the main excel window.</returns>
        public static ArbitraryWindow GetMainExcelWindow()
        {
            var excelHwnd_IntPtr = new IntPtr(Globals.ThisAddIn.Application.Hwnd);
            var excelWindow = new ArbitraryWindow(excelHwnd_IntPtr);
            return excelWindow;
        }
        /// <summary>
        /// Activates the excel window.
        /// </summary>
        public static void ActivateExcelWindow()
        {
            var currentlyActiveForm = Form.ActiveForm;
            //if (currentlyActiveForm != null && currentlyActiveForm.GetType() == typeof(FormProgress)) return;
            var handle = GetMainExcelWindow().Handle;
            BringWindowToTop(handle);
        }
