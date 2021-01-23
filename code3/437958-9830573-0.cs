    DataTable tbl = new DataTable();
    var pck = new OfficeOpenXml.ExcelPackage();
    pck.Load(new System.IO.FileInfo(path).OpenRead());
    if (pck.Workbook.Worksheets.Count != 0) {
    	var ws = pck.Workbook.Worksheets.First();
    	var hasHeader = false; // adjust accordingly '
    	foreach (var firstRowCell in ws.Cells(1, 1, 1, ws.Dimension.End.Column)) {
    		tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
    	}
    	var startRow = hasHeader ? 2 : 1;
    	for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++) {
    		var wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column);
    		tbl.Rows.Add(wsRow.Select(cell => cell.Text).ToArray());
    	}
    }
