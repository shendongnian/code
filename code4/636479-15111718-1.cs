    var series = new Series("First")
                             {
                                 ChartType = SeriesChartType.Spline, //line chart
                                 ChartArea = "chartArea", 
                                 Color = Color.White
                             };
    //generating data
    var random = new Random();
    for (int i = 0; i < 50; i++)
    {
        //random values
        series.Points.AddXY(i, random.Next(100));
    }
    //creating display area
    var chartArea = new ChartArea("chartArea")
                                {
                                    //hiding grid lines
                                    AxisX =
                                        {
                                            LineWidth = 0,
                                            IntervalType = DateTimeIntervalType.NotSet,
                                            LabelStyle = {Enabled = false},
                                            MajorGrid = {LineWidth = 0},
                                            MajorTickMark = {LineWidth = 0}
                                        },
                                    AxisY =
                                        {
                                            LineWidth = 0,
                                            LabelStyle = {Enabled = false},
                                            MajorGrid = {LineWidth = 0},
                                            MajorTickMark = {LineWidth = 0}
                                        },
                                    BackColor = Color.Black
                                };
    //creating chart control
    var chart = new Chart {Dock = DockStyle.Fill, BackColor = Color.Black};
    chart.ChartAreas.Add(chartArea);
    chart.Series.Add(series);
    
    //add chart control to form
    Controls.Add(chart);
