    using Excel = Microsoft.Office.Interop.Excel;
    using System;
    
    namespace ExcelAddIn1
    {
        public partial class ThisAddIn
        {
            private string CurrentFullName { get; set; }
            private event EventHandler SaveAs;
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                CurrentFullName = this.Application.ThisWorkbook.FullName;
    
                this.Application.WorkbookAfterSave += new Excel.AppEvents_WorkbookAfterSaveEventHandler(Application_WorkbookAfterSave);
    
                SaveAs += new EventHandler(ThisAddIn_SaveAs);
            }
    
            void ThisAddIn_SaveAs(object sender, EventArgs e)
            {
                //Do What I want to do if saved as
            }
    
            void Application_WorkbookAfterSave(Excel.Workbook Wb, bool Success)
            {
                if (Wb.FullName != CurrentFullName)
                {
                    CurrentFullName = Wb.FullName;
                    SaveAs.Invoke(null, null);
                }
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
        }
    }
