    // common syntax to  add a Hyperlink to Excel
    object Add(
	[In] object Anchor, 
	[In] string Address, 
	[In, Optional] object SubAddress, 
	[In, Optional] object ScreenTip, 
	[In, Optional] object TextToDisplay
    );
    // your code
    for (int rowIndex=0; rowIndex<result.Rows.Count; rowIndex++)
    {
        for (int columnIndex=0; columnIndex<result.Columns.Count; columnIndex++)
        {
            string yourValue = result.Rows[rowIndex].Item[columnIndex].ToString();
            if (columnIndex!=YOUR_HYPERLINK_COLUMN_INDEX)
                excelDoc2.setCell(1, 1, rowIndex, columnIndex, yourValue);      
            else
            {
                 Excel.Range range = (Range) YOUR_SHEET.Cells[rowIndex, columnIndex];
                 CURRENT_WORKSHEET.Hyperlinks.Add(
                               range, 
                               yourValue, 
                               Type.Missing,"YOUR_SCREEN_TIP",
                               "YOUR_TEXT_TO_DISPLAY");
            } 
        }
    }
