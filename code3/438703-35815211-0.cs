    	using Excel = Microsoft.Office.Interop.Excel;
    	private void ExportDataGrid()
		{
            // Fetch directories
			var dirInfo = new DirectoryInfo(@"C:\Windows\WinSxS\");
			var items = dirInfo.EnumerateDirectories();
			dataGrid.ItemsSource = items;
			var source = dataGrid.ItemsSource;
            // Create Excel app
			var excel = new Excel.Application { Visible = true };
			excel.ScreenUpdating = false; //Some speed-up
			var book = excel.Workbooks.Add();
			var sheet = (Excel.Worksheet)book.Sheets[1];
			int row = -1; //The row in array
			Type type = null;
            // Create array to hold data
			int rows = items.Count(), cols = dataGrid.Columns.Count;
			var arr = new object[rows, cols];
			foreach (DirectoryInfo dir_info in dataGrid.ItemsSource)
			{
				++row;
                // You can also use GetType().GetTypeInfo() as of .NET 4.5+.
                // The return type will be TypeInfo.
				type = dir_info.GetType();
				for (int col = 0; col < cols; ++col)
				{
					var column_name = (string)dataGrid.Columns[col].Header;
					var value = type.GetProperty(column_name).GetValue(dir_info);
					arr.SetValue(value, row, col);
				}
			}
			// Create header
			for (int col = 0; c < cols; ++c)
			{
				sheet.Cells[1, col + 1].Value = dataGrid.Columns[col].Header;
			}
			// Dump array - the fastest way
			sheet.Range["A2"].Resize[rows, cols].Value = arr;
            // Restore screen updating - otherwise Excel will not response to actions
			excel.ScreenUpdating = true;
		}
