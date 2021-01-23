    // using interop, excel tool, interop-excel, core
    public void MyBeforeSave(Microsoft.Office.Interop.Excel.Workbook Wb, bool SaveAsUI, ref bool Cancel)
    {
      //Globals.ThisAddIn.Application.ActiveWorkbook.SaveCopyAs(filename2); // if u use an external class to save (for threading or something else )
      this.Application.ActiveWorkbook.SaveCopyAs(filename); 
    }   
