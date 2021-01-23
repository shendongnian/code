    SummarySettings ss = grid.DisplayLayout.Bands[0].Summaries.Add("SummaryKeyName", 
                         SummaryType.Custom, new FakeCaptionSummary(), 
                         grid.DisplayLayout.Bands[0].Columns["ColumnUsedForCaption"],  
                         SummaryPosition.UseSummaryPositionColumn, 
                         grid.DisplayLayout.Bands[0].Columns["ColumnUsedForCaption"]);
    ss.DisplayFormat = "Subtotals";
