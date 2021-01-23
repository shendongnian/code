		private void copyDataGridContentToClipboard()
		{
			datagridGrupeProductie.SelectAll();
			datagridGrupeProductie.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
			ApplicationCommands.Copy.Execute(null, datagridGrupeProductie);
			datagridGrupeProductie.UnselectAll();
		}
		
		private void rightClickGrupeProductie_Click(object sender, RoutedEventArgs e)
		{
			copyDataGridContentToClipboard();
			Microsoft.Office.Interop.Excel.Application excelApp;
			Microsoft.Office.Interop.Excel.Workbook excelWkbk;
			Microsoft.Office.Interop.Excel.Worksheet excelWksht;
			object misValue = System.Reflection.Missing.Value;
			excelApp = new Microsoft.Office.Interop.Excel.Application();
			excelApp.Visible = true;
			excelWkbk = excelApp.Workbooks.Add(misValue);
			excelWksht = (Microsoft.Office.Interop.Excel.Worksheet)excelWkbk.Worksheets.get_Item(1);
			Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)excelWksht.Cells[1, 1];
			CR.Select();
			excelWksht.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
		}
