    void exporter_ExcelCellFormatting(object sender,Telerik.WinControls.UI.Export.ExcelML.ExcelCellFormattingEventArgs e)
    {
        if (e.GridRowInfoType == typeof(GridViewTableHeaderRowInfo))
        {
            BorderStyles border = new BorderStyles();
            border.Color = Color.Black;
            border.Weight = 2;
            border.LineStyle = LineStyle.Continuous;
            border.PositionType = PositionType.Bottom;
            e.ExcelStyleElement.Borders.Add(border);
        }
        else if (e.GridRowIndex == 2 && e.GridColumnIndex == 1)
        {
            e.ExcelStyleElement.InteriorStyle.Color = Color.Yellow;
            e.ExcelStyleElement.AlignmentElement.WrapText = true;
        }
    }
