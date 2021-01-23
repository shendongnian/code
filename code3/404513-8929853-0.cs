    var workbook = Workbook.Load("spreadsheet.xls");
    var worksheet = workbook.Worksheets[0]; // assuming only 1 worksheet
    var cells = worksheet.Cells;
    var dataTable = new DataTable("datatable");
    // add columns: assuming first row is column headers
    for (int colIndex = cells.FirstColIndex; colIndex <= cells.LastColIndex; colIndex++)
    {
        dataTable.Columns.Add(cells[0, colIndex].StringValue);
    }
    // add rows
    for (int rowIndex = cells.FirstRowIndex + 1; rowIndex <= cells.LastRowIndex; rowIndex++)
    {
        var values = new List<string>();
        foreach(var cell in cells.GetRow(rowIndex))
        {
            values.Add(cell.Value.StringValue);
        }
        dataTable.LoadDataRow(values.ToArray(), true);
    }
