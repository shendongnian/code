    var bgColor = new DotNet.Highcharts.Helpers.BackColorOrGradient(System.Drawing.Color.Transparent);
   
    DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")            
    .InitChart(new Chart { 
                    DefaultSeriesType = ChartTypes.Line,
                    BackgroundColor = bgColor
                })
