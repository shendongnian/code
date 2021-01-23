    void chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
    {
        e.LegendItems.Clear();
        foreach (var series in this.chart1.Series)
        {
            var legendItem = new LegendItem();
            legendItem.SeriesName = series.Name;
            legendItem.ImageStyle = LegendImageStyle.Rectangle;
            legendItem.BorderColor = Color.Transparent;
            legendItem.Name = series.Name + "_legend_item";
            int i = legendItem.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleCenter);
            legendItem.Cells.Add(LegendCellType.Text, series.Name, ContentAlignment.MiddleCenter);
            if (series.Enabled)
                legendItem.Color = series.Color;
            else
                legendItem.Color = Color.FromArgb(100, series.Color);
            e.LegendItems.Add(legendItem);
        }
    }
    
