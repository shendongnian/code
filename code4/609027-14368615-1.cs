    	private static void printExcelValues(Worksheet xSheet)
		{
			Range xRng =xSheet.Cells.SpecialCells(
				XlCellType.xlCellTypeConstants);
			var arr = new string[xRng.Rows.Count,xRng.Columns.Count];
			foreach (Range item in xRng)
			{
				arr[item.Row-1,item.Column-1]=item.Value.ToString();
			}
		}
