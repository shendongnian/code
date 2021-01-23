    public static DataSet ReadWorkbook(string excelFileName, bool useFirstRowAsColumnName = false)
    {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        var workBook = excel.Workbooks.Open(excelFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);//MLHIDE
        try
        {
            System.Data.DataSet ds = new DataSet(excelFileName);
            foreach (var sheet0 in workBook.Worksheets)
            {
                var sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheet0;
                try
                {
                    var dt = readSheet(sheet, useFirstRowAsColumnName);
                    if (dt != null)
                        ds.Tables.Add(dt);
                }
                finally
                {
                    releaseObject(sheet);
                }
            }
            return ds;
        }
        finally
        {
            workBook.Close(true, null, null);
            excel.Quit();
    
            releaseObject(workBook);
            releaseObject(excel);
        }
    }
    
    /// <summary>
    /// Returns null for empty sheets or if sheet is not found.
    /// </summary>
    public static DataTable ReadSheet(string excelFileName, string sheetName, bool useFirstRowAsColumnName = false)
    {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        var workBook = excel.Workbooks.Open(excelFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);//MLHIDE
        try
        {
            foreach (var sheet0 in workBook.Worksheets)
            {
                var sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheet0;
                try
                {
                    if (sheet.Name.Equals_Wildcard(sheetName))
                    {
                        var dt = readSheet(sheet, useFirstRowAsColumnName);
                        if (dt != null)
                            return dt;
                    }
                }
                finally
                {
                    releaseObject(sheet);
                }
            }
            return null;
        }
        finally
        {
            workBook.Close(true, null, null);
            excel.Quit();
    
            releaseObject(workBook);
            releaseObject(excel);
        }
    }
    
    /// <summary>
    /// Returns null for empty sheets
    /// </summary>
    private static DataTable readSheet(Microsoft.Office.Interop.Excel.Worksheet sheet, bool useFirstRowAsColumnName = false)
    {
        var range = sheet.UsedRange;
        try
        {
            object[,] values = (object[,])range.Value2;
            int rowCount = values.GetLength(0);
            int colCount = values.GetLength(1);
            int rowCount0 = rowCount;
            int colCount0 = colCount;
            #region find row-col count
            {
                bool ok = false;
                for (int row = rowCount; row > 0; row--)
                    if (!ok)
                        for (int col = colCount; col > 0; col--)
                        {
                            var val = values[row, col];
                            if ((val != null) && (!System.Convert.ToString(val).IsNullOrEmpty()))
                            {
                                rowCount = row;
                                ok = true;
                                break;
                            }
                        }
                    else
                        break;
            }
            {
                bool ok = false;
                for (int col = colCount; col > 0; col--)
                    if (!ok)
                    for (int row = rowCount; row > 0; row--)
                        {
                            var val = values[row, col];
                            if ((val != null) && (!System.Convert.ToString(val).IsNullOrEmpty()))
                            {
                                colCount = col;
                                ok = true;
                                break;
                            }
                        }
                    else
                        break;
            }
            #endregion
            if ((rowCount > 0) && (colCount > 0))
            {
                var dt = new DataTable(sheet.Name);
                for (int col = 1; col <= colCount; col++)
                    dt.Columns.Add(useFirstRowAsColumnName ? values[1, col].ToString_NullProof() : col.ToString());
    
                var values1 = values.Cast<object>();
                for (int row = useFirstRowAsColumnName ? 1 : 0; row < rowCount; row++)
                    dt.Rows.Add(values1.Skip(row * colCount0).Take(colCount).ToArray());
                return dt;
            }
            else
                return null;
        }
        finally
        {
            releaseObject(range);
        }
    }
    
    private static void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            throw new Exception("Unable to release the Object " + ex.ToString(), ex);//MLHIDE
        }
        finally
        {
            GC.Collect();
        }
    }
