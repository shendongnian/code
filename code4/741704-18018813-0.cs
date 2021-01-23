    using (ExcelRange Title = Cells[1, 1, 1, dt.Columns.Count]) {
        Title.Merge = true;
        Title.Style.Font.Size = 18;
        Title.Style.Font.Bold = true;
        Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        Title.Style.Fill.BackgroundColor.SetColor(systemColor);
        Title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        Title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        Title.Style.TextRotation = 90;
        Title.Value = "This is my title";
    }
