    Data data = new Data(new[]
    {
        new Point { Y = 1, Color = System.Drawing.Color.Red },
        new Point { Y = 8, Color = System.Drawing.Color.Blue },
        new Point { Y = 9, Color = System.Drawing.Color.Green },
        new Point { Y = 6, Color = System.Drawing.Color.Black }
    });
    Highcharts chart1 = new Highcharts("chart1")
        .SetXAxis(new XAxis { Categories = new[] { "Ödmjukhet", "Engagemang", "Kompetens", "Lönsamhet" } })
        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Betygskalan" } })
        .SetSeries(new Series { Data = data, Name = "Snittbetyg" })
        .SetTitle(new Title { Text = "Örebro Statistik" })
        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
        .SetLegend(new Legend { Enabled = false });
