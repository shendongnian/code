    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    private void ExportToExcel(DataTable Table, string ReportName, string Filename)
    {
      Excel.Application oXL;
      Excel.Workbook oWB;
      Excel.Worksheet oSheet;
      Excel.Range oRange;
      
      // Start Excel and get Application object.
      oXL = new Excel.Application();
      
      // Set some properties
      oXL.Visible = true;
      oXL.DisplayAlerts = false;
      
      // Get a new workbook.
      oWB = oXL.Workbooks.Add(Missing.Value);
      
      // Get the active sheet
      oSheet = (Excel.Worksheet)oWB.ActiveSheet ;
      oSheet.Name = "Report";
      
      int rowCount = 3;
      foreach (DataRow dr in Table.Rows)
      {
          for (int i = 1; i < Table.Columns.Count+1; i++)
          {
              // Add the header the first time through
              if (rowCount==3)
              {
                  oSheet.Cells[1, i] = Table.Columns[i - 1].ColumnName;
                  rowCount++;
              }
              oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
          }
          rowCount++;
      }
      
      // Resize the columns
      oRange = oSheet.get_Range(oSheet.Cells[3, 1],
                    oSheet.Cells[rowCount, Table.Columns.Count]);
      oRange.EntireColumn.AutoFit();
      
      // Set report title *after* we adjust column widths
      oSheet.Cells[1,1] = ReportName;
      
      // Save the sheet and close
      oSheet = null;
      oRange = null;
      oWB.SaveAs(Filename, Excel.XlFileFormat.xlWorkbookNormal,
          Missing.Value, Missing.Value, Missing.Value, Missing.Value,
          Excel.XlSaveAsAccessMode.xlExclusive,
          Missing.Value, Missing.Value, Missing.Value,
          Missing.Value, Missing.Value);
      oWB.Close(Missing.Value, Missing.Value, Missing.Value);
      oWB = null;
      oXL.Quit();
      
      // Clean up
      // NOTE: When in release mode, this does the trick
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }
