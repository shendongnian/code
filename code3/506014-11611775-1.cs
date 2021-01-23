    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelAddIn1
    {
        public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                this.Application.WorkbookAfterSave += new Excel.AppEvents_WorkbookAfterSaveEventHandler(Application_WorkbookAfterSave);
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
            void Application_WorkbookAfterSave(Excel.Workbook Wb, bool Success)
            {
                var x = Wb.FullName;
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
    }
