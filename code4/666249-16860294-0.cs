    protected override void OnToggledSelection (ShinobiChart chart, SChartRadialDataPoint dataPoint, SChartRadialSeries series, PointF pixelPoint)
    {
        Item item = myItems[dataPoint.index];
        SmartDataSource sDataSource = chart.DataSource as SmartDataSource;
 
        if (sDataSource != NULL) {
            sDataSource.SetToShowDataForItem(item); 
            chart.ReloadData();
            chart.RedrawChart();
        }
    }
