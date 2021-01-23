    		private static void printExcelValues(Worksheet xSheet)
		{
			Range xRng =xSheet.Cells.SpecialCells(
				XlCellType.xlCellTypeConstants);
			foreach (Range item in xRng)
			{
				Console.WriteLine(item.Value.ToString());
			}
			
		}
