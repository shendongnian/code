    private int AutoSizeMergedCells(CellRange myMergedCells, string text)
        {
            var file = new ExcelFile();
            file.Worksheets.Add("AutoSize");
            var ws = file.Worksheets[0];
            ws.Cells[0, 0].Column.Width = myMergedCells.Sum(x => x.Column.Width);
            ws.Cells[0, 0].Value = text;
            ws.Cells[0, 0].Style.WrapText = true;
            ws.Cells[0, 0].Row.AutoFit();
            var result = ws.Cells[0, 0].Row.Height;
            file = null;
            return result;
        }
