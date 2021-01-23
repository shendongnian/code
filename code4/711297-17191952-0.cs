        var ws = _excel.Workbook.Worksheets["myTemplateWorksheet"];
        var dim = ws.Dimension;
        // first loop through all non-merged cells
        for (int r = dim.Start.Row; r <= dim.End.Row; ++r)
            for (int c = dim.Start.Column; c <= dim.End.Column; ++c)
            {
                if (ws.Cells[r, c].Merge) continue;
                string s = GetRangeText(ws.Cells[r,c]);
                if (string.IsNullOrEmpty(s)) continue;
                if (s.StartsWith("^^"))
                    ProcessCell(ws.Cells[r, c], s.Substring(2));
            }
        // then loop through all merged ranges
        foreach (string mc in ws.MergedCells)
        {
            string s = GetRangeText(ws.Cells[mc]);
            if (string.IsNullOrEmpty(s)) continue;
            if (s.StartsWith("^^"))
                ProcessCell(ws.Cells[mc], s.Substring(2));
         }
