    var bindingSource = (BindingSource)this.peopleDataGridView.DataSource;
    var dataTable = ((DataView)bindingSource.List).Table;
    var ef = new ExcelFile();
    var ws = ef.Worksheets.Add(dataTable.TableName);
    // Insert data table in worksheet, starting from worksheet's first row and column and    include column headers
    ws.InsertDataTable(dataTable, 0, 0, true);
    foreach(ExcelCell cell in ws.GetUsedCellRange(true))
       cell.Style.FillPattern.SetSolid(Color.Red);
    ef.SaveXls(dataTable.TableName + ".xls");
