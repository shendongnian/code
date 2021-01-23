    public static string GetMinimalUsedRangeAddress(Excel.Worksheet sheet)
    {
        string address = String.Empty;
        try
        {
            int rowMax = 0;
            int colMax = 0;
            Excel.Range usedRange = sheet.UsedRange;
            Excel.Range lastCell = usedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            int lastRow = lastCell.Row;
            int lastCol = lastCell.Column;
            int rowMin = lastRow + 1;
            int colMin = lastCol + 1;
            int rr = usedRange.Rows.Count;
            int cc = usedRange.Columns.Count;
            for (int r = 1; r <= rr; r++)
            {
                for (int c = 1; c <= cc; c++)
                {
                    Excel.Range cell = usedRange.Cells[r, c] as Excel.Range;
                    if (cell != null && cell.Value != null && !String.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        if (cell.Row > rowMax)
                            rowMax = cell.Row;
                        if (cell.Column > colMax)
                            colMax = cell.Column;
                        if (cell.Row < rowMin)
                            rowMin = cell.Row;
                        if (cell.Column < colMin)
                            colMin = cell.Column;
                    }
                    MRCO(cell);
                }
            }
            if (!(rowMax == 0 || colMax == 0 || rowMin == lastRow + 1 || colMin == lastCol + 1))
                address = Cells2Address(rowMin, colMin, rowMax, colMax);
            MRCO(lastCell);
            MRCO(usedRange);
        }
        catch (Exception ex)
        {
            // log as needed
        }
        return address; // caller should test return for String.Empty
    }
    public static string Cells2Address(int row1, int col1, int row2, int col2)
    {
        return ColNum2Letter(col1) + row1.ToString() + ":" + ColNum2Letter(col2) + row2.ToString();
    }
    public static string ColNum2Letter(int colNum)
    {
        if (colNum <= 26) 
            return ((char)(colNum + 64)).ToString();
        colNum--; //decrement to put value on zero based index
        return ColNum2Letter(colNum / 26) + ColNum2Letter((colNum % 26) + 1);
    }
    public static void MRCO(object obj)
    {
        if (obj == null) { return; }
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }
        catch
        {
            // ignore, cf: http://support.microsoft.com/default.aspx/kb/317109
        }
        finally
        {
            obj = null;
        }
    }
