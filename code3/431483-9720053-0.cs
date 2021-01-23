    private void button1_Click(object sender, EventArgs e)
    {
        Excel.Application xlApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        Excel.Workbook xlWorkbook = xlApp.ActiveWorkbook;
        Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        xlWorksheet.Cells[1,1] = "Name";
    }
  
