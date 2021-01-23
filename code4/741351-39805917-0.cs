    public static DataSet ReadWorkbook(string fn, bool useFirstRowAsColumnName = false)
    {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        var workBook = excel.Workbooks.Open(fn, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);//MLHIDE
        try
        {
            System.Data.DataSet ds = new DataSet(fn);
            foreach (var sheet0 in workBook.Worksheets)
            {
                var sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheet0;
                var range = sheet.UsedRange;
    
                try
                {
                    object[,] values = (object[,])range.Value2;
                    int rowCount = values.GetLength(0);
                    int colCount = values.GetLength(1);
                    if ((rowCount > 0) && (rowCount > 0))
                    {
                        var dt = new DataTable(sheet.Name);
                        ds.Tables.Add(dt);
    
                        for (int col = 0; col < colCount; col++)
                            dt.Columns.Add(useFirstRowAsColumnName ? values[1, col + 1].ToString_NullProof() : (col + 1).ToString());
    
                        var values1 = values.Cast<object>();
                        for (int row = useFirstRowAsColumnName ? 1 : 0; row <= rowCount; row++)
                            dt.Rows.Add(values1.Skip(row * colCount).Take(colCount).ToArray());
                    }
                }
                finally
                {
                    releaseObject(sheet);
                    releaseObject(range);
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
