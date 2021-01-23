    static public void PopulateABigNumberOfCells(Excel.Application xlApp, DataTable dataTable)
    {
    //Turn off Excel updating
    SwitchApplicationSettings(xlApp,false);
    
    //Populate a 2D array - via a DataTable in this example
    object[,] values = (object[,])Array.CreateInstance(typeof(object), new int[2] { dataTable.Rows.Count, dataTable.Columns.Count }, new int[2] { 1, 1 });
    for (int i = 0; i < dataTablea.Rows.Count; i++)
    {
     for (int j = 0; j < dataTable.Columns.Count; j++)
     {
      values[i + 1, j + 1] = dataTable.Rows[i][j] == DBNull.Value ? 0 : dataTable.Rows[i][j];
     }
    }
    
    //Populate all cells in one swoop 
    leftCellNum = XlHelper.ColumnNameToNumber(leftColumn);
    string rightBottom = XlHelper.ColumnNumberToName(leftCellNum + dataTable.Columns.Count - 1);
    using (var targetRange = xlApp.Range[leftColumn + (startingRow) + ":" + rightBottom + (startingRow + dataTable.Rows.Count - 1)].WithComCleanup())
    {
    targetRange.Resource.Value2 = values;
    }
    
    //Turn on Excel updating
    SwitchApplicationSettings(xlApp,true);
    }
    static public void SwitchApplicationSettings(Excel.Application xlApp, bool on)
    {
    xlApp.ScreenUpdating = on;
    xlApp.DisplayAlerts = on;
    xlApp.Calculation = on ? XlCalculation.xlCalculationAutomatic : XlCalculation.xlCalculationManual;;
    xlApp.UserControl = on;
    xlApp.EnableEvents = on;
    }
