          Excel.Application oXL;
           Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRange;
                 var filepath = "/somefilepath";
                // Start Excel and get Application object.  
                oXL = new Excel.Application();
                // Set some properties  
                oXL.Visible = true;
                oXL.DisplayAlerts = false;
                // Get a new workbook.  
                oWB = oXL.Workbooks.Add(Missing.Value);
                // Get the Active sheet  
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = "Data";
                int rowCount = 1;
                string strExpr;
                string strSort;
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through  
                        if (rowCount == 2)
                        {
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        }
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }
               //Freze the first row
                oSheet.Application.ActiveWindow.SplitRow = 1;
                oSheet.Application.ActiveWindow.FreezePanes = true;
                // Resize the columns  
                oRange = oSheet.get_Range(oSheet.Cells[1, 1],
                              oSheet.Cells[rowCount, dt.Columns.Count]);
                oRange.EntireColumn.AutoFit();
                // Save the sheet and close  
                oSheet = null;
                oRange = null;
                oWB.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oWB = null;
                oXL.Quit();
