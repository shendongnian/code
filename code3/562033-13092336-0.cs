    var chart = new Chart
    {
        Height = 300,
        Width = 500
    };
    chart.Legends.Add(new Legend());
    chart.Series.Add(new Series());
    chart.ChartAreas.Add(new ChartArea());
    chart.Titles.Add(new Title());
    chart.SaveImage(savePath);
