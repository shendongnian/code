    Microsoft.Office.Interop.Excel._Application ExcelApp;
    private bool IsRange(string refr) {
       try {
          var unused = ExcelApp.Range[cellReference, Type.Missing];
          
          return true;
       }
       catch {
          return false;
       }
    }
