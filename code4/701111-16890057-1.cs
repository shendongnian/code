    //Dump the datatable onto the sheet in one operation
    public void InsertDataTableIntoExcel(Application xlApp, DataTable dt, Reectangle QueryDataArea)
    {	
    	TurnOnOffApplicationSettings(false);
    	using (var rn = xlApp.Range[XlHelper.ColumnNumberToName(QueryDataArea.X) + QueryDataArea.Y + ":" + XlHelper.ColumnNumberToName(QueryDataArea.X + QueryDataArea.Width - 1) + (QueryDataArea.Y + QueryDataArea.Height)].WithComCleanup())
    	{
    		rn.Resource.Value2 = Populate2DArray(dt);
    	}
    	TurnOnOffApplicationSettings(true);
    }
    private object[,] Populate2DArray(DataTable dt)
    {
        object[,] values = (object[,])Array.CreateInstance(typeof(object), new int[2] { dt.Rows.Count + 1, dt.Columns.Count + 1}, new int[2] { 1, 1 });
    
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                values[i + 1, j + 1] = dt.Rows[i][j] == DBNull.Value ? "" : dt.Rows[i][j];
            }
        }
        return values;
    }
    
    public static string ColumnNumberToName(Int32 columnNumber)
    {
        Int32 dividend = columnNumber;
        String columnName = String.Empty;
        Int32 modulo;    
        while (dividend > 0)
        {
            modulo = (dividend - 1)%26;
            columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
            dividend = (Int32) ((dividend - modulo)/26);
        }    
        return columnName;
    }
    
    public static Int32 ColumnNameToNumber(String columnName)
    {
        if (String.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");    
        char[] characters = columnName.ToUpperInvariant().ToCharArray();    
        Int32 sum = 0;    
        for (Int32 i = 0; i < characters.Length; i++)
        {
            sum *= 26;
            sum += (characters[i] - 'A' + 1);
        }    
        return sum;
    }
    private static XlCalculation xlCalculation = XlCalculation.xlCalculationAutomatic;
    public void TurnOnOffApplicationSettings(Excel.Application xlApp, bool on)
    {
        xlApp.ScreenUpdating = on;
        xlApp.DisplayAlerts = on;
    	if (on)
    	{		
            xlApp.Calculation = xlCalculation;
    	}
    	else
    	{
    	    xlCalculation = xlApp.Calculation;
    	    xlApp.Calculation = XlCalculation.xlCalculationManual;
    	}
        xlApp.UserControl = on;
        xlApp.EnableEvents = on;
    }
