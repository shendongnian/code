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
        }
    }
