    DataTable table = getDataSource();
    FileInfo fileInfo = new FileInfo(path);
    var excel = new ExcelPackage(fileInfo);
    var wsData = excel.Workbook.Worksheets.Add("Data-Worksheetname");
    var wsPivot = excel.Workbook.Worksheets.Add("Pivot-Worksheetname");
    wsData.Cells["A1"].LoadFromDataTable(table, true, OfficeOpenXml.Table.TableStyles.Medium6);
    if (table.Rows.Count != 0)
    {
        foreach (DataColumn col in table.Columns)
        {
            // format all dates in german format (adjust accordingly)
            if (col.DataType == typeof(System.DateTime))
            {
                var colNumber = col.Ordinal + 1;
                var range = wsData.Cells[2, colNumber, table.Rows.Count + 1, colNumber];
                range.Style.Numberformat.Format = "dd.MM.yyyy";
            }
        }
    }
    var dataRange = wsData.Cells[wsData.Dimension.Address.ToString()];
    dataRange.AutoFitColumns();
    var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["A3"], dataRange, "Pivotname");
    pivotTable.MultipleFieldFilters = true;
    pivotTable.RowGrandTotals = true;
    pivotTable.ColumGrandTotals = true;
    pivotTable.Compact = true;
    pivotTable.CompactData = true;
    pivotTable.GridDropZones = false;
    pivotTable.Outline = false;
    pivotTable.OutlineData = false;
    pivotTable.ShowError = true;
    pivotTable.ErrorCaption = "[error]";
    pivotTable.ShowHeaders = true;
    pivotTable.UseAutoFormatting = true;
    pivotTable.ApplyWidthHeightFormats = true;
    pivotTable.ShowDrill = true;
    pivotTable.FirstDataCol = 3;
    pivotTable.RowHeaderCaption = "Claims";
    var modelField = pivotTable.Fields["Model"];
    pivotTable.PageFields.Add(modelField);
    modelField.Sort = OfficeOpenXml.Table.PivotTable.eSortType.Ascending;
    var countField = pivotTable.Fields["Claims"];
    pivotTable.DataFields.Add(countField);
    var countryField = pivotTable.Fields["Country"];
    pivotTable.RowFields.Add(countryField);
    var gspField = pivotTable.Fields["GSP / DRSL"];
    pivotTable.RowFields.Add(gspField);
    var oldStatusField = pivotTable.Fields["Old Status"];
    pivotTable.ColumnFields.Add(oldStatusField);
    var newStatusField = pivotTable.Fields["New Status"];
    pivotTable.ColumnFields.Add(newStatusField);
    var submittedDateField = pivotTable.Fields["Claim Submitted Date"];
    pivotTable.RowFields.Add(submittedDateField);
    submittedDateField.AddDateGrouping(OfficeOpenXml.Table.PivotTable.eDateGroupBy.Months | OfficeOpenXml.Table.PivotTable.eDateGroupBy.Days);
    var monthGroupField = pivotTable.Fields.GetDateGroupField(OfficeOpenXml.Table.PivotTable.eDateGroupBy.Months);
    monthGroupField.ShowAll = false;
    var dayGroupField = pivotTable.Fields.GetDateGroupField(OfficeOpenXml.Table.PivotTable.eDateGroupBy.Days);
    dayGroupField.ShowAll = false;
    excel.Save();
