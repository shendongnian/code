    #using Microsoft.Office.Interop;
    
    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    			         
    xlApp = new Excel.ApplicationClass();
    xlWorkBook = xlApp.Workbooks.Add(1);
    xlWorkSheet = Excel.Worksheet xlWorkBook.ActiveSheet;
    
    // Notice the index starting at [1,1] (row,column)
    for (int i=1; i<DataGridView.Columns.Count+1; i++)
    	xlWorkSheet.Cells[1, i] = DataGridView.Columns[i - 1].HeaderText;
    		
    for each(DataGridViewRow row in DataGridView.Rows)
    {
    	for each (DataGridViewColumn column in DataGridView.Columns)
    	{
    		xlWorkSheet.Cells[row.Index+2,column.Index+1] = DataGridView.Rows[row.Index].Cells[column.Index].Value;
    	}
    }
