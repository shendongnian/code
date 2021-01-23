    [ExcelFunction(IsMacroType=true)]
    public static object[,] ReadFormulasMacroType(
            [ExcelArgument(AllowReference=true)]object arg)
    {
        ExcelReference theRef = (ExcelReference)arg;
        int rows = theRef.RowLast - theRef.RowFirst + 1;
        object[,] res = new object[rows, 1];
        for(int i=0; i < rows; i++) 
        {
            ExcelReference cellRef = new ExcelReference( 
                theRef.RowFirst+i, theRef.RowFirst+i, 
                theRef.ColumnFirst,theRef.ColumnFirst,
                theRef.SheetId );
            res[i,0] = XlCall.Excel(XlCall.xlfGetFormula, cellRef);
        }
        return res;
    }
