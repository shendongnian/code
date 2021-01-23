    DataTable dt = new DataTable();
    dt.Columns.Add("Column1", typeof(int));
    dt.Columns.Add("Column2", typeof(string));
    dt.Columns.Add("Column3", typeof(int));
    for (int i = 0; i < 100; i++)
    {
        dt.Rows.Add(i / 10 + 1, "Item " + i.ToString(), i);
    }
    Workbook _workbook = new Workbook(@"e:\test2\book1.xlsx");
    Worksheet _worksheet = _workbook.Worksheets[0];
    Range maxRange = _workbook.Worksheets[_worksheet.Name].Cells.MaxDisplayRange;
    //workbook.Worksheets[_worksheet.WorksheetName].Cells.ClearRange((int)_worksheet.StartRow, (int)_worksheet.StartColumn, maxRange.RowCount, maxRange.ColumnCount);
    _workbook.Worksheets[_worksheet.Name].Cells.ClearRange((int)maxRange.FirstRow, (int)maxRange.FirstColumn, maxRange.RowCount, maxRange.ColumnCount);
    //workbook.Worksheets[_worksheet.WorksheetName].Cells.ImportDataTable(data.Tables[_worksheet.FixedWorksheetName], false, _worksheet.ExportDataStartRow ?? 0, 0)
    _workbook.Worksheets[_worksheet.Name].Cells.ImportDataTable(dt, false, 0, 0);
    //Instantiate the error checking options
    ErrorCheckOptionCollection opts = _workbook.Worksheets[_worksheet.Name].ErrorCheckOptions;
    int index = opts.Add();
    ErrorCheckOption opt = opts[index];
    //Disable the numbers stored as text option
    opt.SetErrorCheck(ErrorCheckType.TextNumber, false);
    opt.AddRange(CellArea.CreateCellArea(0, 0, _workbook.Worksheets[_worksheet.Name].Cells.MaxDataRow, _workbook.Worksheets[_worksheet.Name].Cells.MaxDataColumn));
    string _exportPath = @"e:\test2\ouput_book1.xlsx";
    //Save the worksheet at an appropriate configured location and assign path to _exportPath..
    _workbook.Save(_exportPath);
