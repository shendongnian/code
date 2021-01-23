    using (var range = worksheet.Cells[1, 1, 1, 5]) 
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
        }
