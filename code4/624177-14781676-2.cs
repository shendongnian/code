    IQueryable<YourModel> model;
    ChartData chartData = new ChartData();
    Highcharts chart = new HighChart("chart_time_series");
    try
    {
        model = db.ClassInstanceDetails.AsQueryable();
        chartData = GetTimeSeriesData(model, ChartTypes.Line);
        chart = TimeSeriesZoomable(chartData.ToArray(), another_options);
    }
    catch (Exception e)
    {
    }
