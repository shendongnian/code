    using (var wb = new XLWorkbook())
    {
        using (var ws = wb.AddWorksheet("Test"))
        {
            ws.Cell("A1").Value = 42;
            ws.Cell("A1").AddConditionalFormat().WhenLessThan(100)
                .Fill.SetBackgroundColor(XLColor.Red);
        }
        wb.SaveAs(@"C:\Dev\Test.xlsx");
    }
