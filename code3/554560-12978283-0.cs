    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.Office.Tools.Excel;
    using Office = Microsoft.Office.Core;
    using Microsoft.VisualStudio.Tools.Applications.Runtime;
    Excel.Worksheet wsheet =
      (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
