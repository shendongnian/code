    chartSel.Legends.Add(ySeries.Name);
    chartSel.Series[ySeries.Name].IsVisibleInLegend = false;
    chartSel.Legends[ySeries.Name].CustomItems.Clear();
    LegendItem li = new LegendItem();
    li.ImageStyle = LegendImageStyle.Line;
    li.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.TopLeft);
    li.Cells[0].BackColor = Color.CornflowerBlue; //color is only to see the cell bounds
    li.Cells.Add(LegendCellType.Text, ySeries.Name, ContentAlignment.TopLeft);
    li.Cells[1].BackColor = Color.Aquamarine; //color is only to see the cell bounds
    chartSel.Legends[ySeries.Name].CustomItems.Add(li);
