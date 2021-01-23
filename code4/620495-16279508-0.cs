    public partial class ThisAddIn
    {
        ExcelWindow window;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            window = new ExcelWindow();
            Application.WorkbookBeforeClose += new Excel.AppEvents_WorkbookBeforeCloseEventHandler(Application_WorkbookBeforeClose);
            Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(Application_WorkbookActivate);
            Application.WorkbookDeactivate += new Excel.AppEvents_WorkbookDeactivateEventHandler(Application_WorkbookDeactivate);
        }
        void Application_WorkbookDeactivate(Excel.Workbook Wb)
        {
            window.ReleaseHandle();
        }
        void Application_WorkbookActivate(Excel.Workbook Wb)
        {
            window.AssignHandle(new IntPtr(Application.Hwnd));
        }
        void Application_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel)
        {
            if (Application.Workbooks.Count > 1 || window.Handle == IntPtr.Zero) return;
            Cancel = true;
            window.ReleaseHandle();
            Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(Application.Quit), null);
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #region VSTO generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
