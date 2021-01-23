    var excelType = Type.GetTypeFromProgID("Excel.Application");
    dynamic excel = Activator.CreateInstance(excelType);
    excel.Visible = true;
    excel.Workbooks.Add();
    excel.Cells(1, 1).Value = "Hello";
    excel.Cells(1, 1).Font.Size = "14";
    excel.Columns(@"A:A").ColumnWidth = 20;
