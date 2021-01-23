            int currentXLLine = 1; // line in xls file to start
            int currentId = -1;    // current sellID  
            int detailCount = 1;
            int beginSumLine = currentXLLine+3;
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                if ((currentId != (int)dt.Rows[i][0])) 
                {
                    if (i != 0)
                    {
                        cell = oSheet.Cells[currentXLLine+1, 7];
                        cell.Font.Bold = true;
                        cell.HorizontalAlignment = ExcelApp.Constants.xlRight;
                        cell.Value = "OVERALL:";
                        cell = oSheet.Cells[currentXLLine + 1, 8];
                        cell.Formula = "=SUM(H"+beginSumLine.ToString()+":H" + currentXLLine.ToString() + ")";
                        cell.Font.Bold = true;
                        cell.HorizontalAlignment = ExcelApp.Constants.xlRight;
                        cell = oSheet.Columns[7];
                        Past.AutoFitColumn(oSheet, 7);
                        cell.NumberFormat = "# ##0.00";
                        cell = oSheet.Columns[8];
                        Past.AutoFitColumn(oSheet, 8);
                        cell.NumberFormat = "# ##0.00";
                        cell.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                        
                        currentXLLine += 3;
                        detailCount = 1;
                    }
                    
                    oRange = oSheet.get_Range("B" + currentXLLine.ToString(), "C" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlRight;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = false;
                    oSheet.Cells[currentXLLine, 2] = "SellDate";
                    oRange = oSheet.get_Range("D" + currentXLLine.ToString(), "E" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlLeft;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = false;
                    oSheet.Cells[currentXLLine, 4] = dt.Rows[i][3].ToString();
                    beginSumLine = currentXLLine + 3;
                    currentXLLine += 2;
                    
                    oRange = oSheet.get_Range("C" + currentXLLine.ToString(), "E" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = true;
                    oRange = oSheet.get_Range("B" + currentXLLine.ToString(), "B" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = true;
                    oRange = oSheet.get_Range("F" + currentXLLine.ToString(), "F" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = true;
                    oRange = oSheet.get_Range("G" + currentXLLine.ToString(), "G" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = true;
                    oRange = oSheet.get_Range("H" + currentXLLine.ToString(), "H" + currentXLLine.ToString());
                    oRange.Merge(Type.Missing);
                    oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
                    oRange.HorizontalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.VerticalAlignment = ExcelApp.Constants.xlCenter;
                    oRange.EntireRow.Font.Bold = true;
                    oSheet.Cells[currentXLLine, 2] = "№";
                    oSheet.Cells[currentXLLine, 3] = "ProductName";
                    oSheet.Cells[currentXLLine, 6] = "Quantity";
                    oSheet.Cells[currentXLLine, 7] = "Price";
                    oSheet.Cells[currentXLLine, 8] = "Sum";
                    currentXLLine += 1;
                }
            
            oSheet.Cells[currentXLLine, 2] = (detailCount).ToString(); //rowView.Row["Ассортимент"].ToString();
            cell = oSheet.Cells[currentXLLine, 2];
            cell.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            oSheet.Cells[currentXLLine, 3] = (string)dt.Rows[i][4];
            cell = oSheet.Cells[currentXLLine, 3];
            cell.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            oRange = oSheet.get_Range("C" + (currentXLLine).ToString(), "E" + (currentXLLine).ToString());
            oRange.Merge(Type.Missing);
            oRange.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            oSheet.Cells[currentXLLine, 6] = dt.Rows[i][5].ToString();
            cell = oSheet.Cells[currentXLLine, 6];
            cell.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            oSheet.Cells[currentXLLine, 7] = dt.Rows[i][6].ToString();
            cell = oSheet.Cells[currentXLLine, 7];
            cell.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            oSheet.Cells[currentXLLine, 8] = Convert.ToInt16(dt.Rows[i][5])*Convert.ToDouble(dt.Rows[i][6]);
            cell = oSheet.Cells[currentXLLine, 8];
            cell.BorderAround(ExcelApp.XlLineStyle.xlContinuous, ExcelApp.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            detailCount += 1;
            currentXLLine += 1;
            currentId = (int)dt.Rows[i][0];
        }
  
    cell = oSheet.Cells[currentXLLine + 1, 7];
      cell.Font.Bold = true;
      cell.HorizontalAlignment = ExcelApp.Constants.xlRight;
      cell.Value = "OVERALL:";
      cell = oSheet.Cells[currentXLLine + 1, 8];
      cell.Formula = "=SUM(H" + beginSumLine.ToString() + ":H" + currentXLLine.ToString() + ")";
      cell.Font.Bold = true;
      cell.HorizontalAlignment = ExcelApp.Constants.xlRight;
