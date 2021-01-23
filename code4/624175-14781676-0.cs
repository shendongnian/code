    public static Highcharts TimeSeriesZoomable(Series[] Series, Number MinRange, Number PointInterval, DateTime PointStartDate, AxisTypes XAxisType = AxisTypes.Datetime, string Title = "", string SubTitle = "", string XAxisTitle = "", string YAxisTitle = "", string ToolTipFormat = "", string YAxisLabel = "")
        {
            Highcharts chart = new Highcharts("chart")
                .SetOptions(new GlobalOptions { Global = new Global { UseUTC = false } })
                .InitChart(new Chart { ZoomType = ZoomTypes.X, SpacingRight = 20, DefaultSeriesType = ChartTypes.Area, Height = 300, BorderRadius = 0 })
                .SetTitle(new Title { Text = Title })
                .SetSubtitle(new Subtitle { Text = SubTitle })
                .SetXAxis(new XAxis
                {
                    Type = XAxisType,
                    MinRange = MinRange,
                    Title = new XAxisTitle { Text = XAxisTitle }
                })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = YAxisTitle },
                    Min = 0.6,
                    StartOnTick = false,
                    EndOnTick = false,
                    Labels = new YAxisLabels
                    {
                        Formatter = @"function() { return this.value +' " + YAxisLabel + "';}"
                    }
                })
                .SetTooltip(new Tooltip { Shared = true/*, Formatter = @"function() { return ''+ this.x +' - '+ this.y +' " + ToolTipFormat + "'; }" */})
                .SetLegend(new Legend { Enabled = true, VerticalAlign = VerticalAligns.Top })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        LineWidth = 3,
                        Marker = new PlotOptionsLineMarker
                        {
                            Enabled = false,
                            States = new PlotOptionsLineMarkerStates
                            {
                                Hover = new PlotOptionsLineMarkerStatesHover
                                {
                                    Enabled = true,
                                    Radius = 5
                                }
                            }
                        },
                        Shadow = false,
                        States = new PlotOptionsLineStates { Hover = new PlotOptionsLineStatesHover { LineWidth = 3 } },
                        PointInterval = PointInterval,
                        PointStart = new PointStart(PointStartDate)
                    },
                    Spline = new PlotOptionsSpline
                    {
                        LineWidth = 3,
                        Marker = new PlotOptionsSplineMarker
                        {
                            Enabled = false,
                            States = new PlotOptionsSplineMarkerStates
                            {
                                Hover = new PlotOptionsSplineMarkerStatesHover
                                {
                                    Enabled = true,
                                    Radius = 5
                                }
                            }
                        },
                        Shadow = false,
                        States = new PlotOptionsSplineStates { Hover = new PlotOptionsSplineStatesHover { LineWidth = 3 } },
                        PointInterval = PointInterval,
                        PointStart = new PointStart(PointStartDate)
                    },
                    Area = new PlotOptionsArea
                    {
                        //FillColor = new BackColorOrGradient(new Gradient
                        //{
                        //    LinearGradient = new[] { 0, 0, 0, 300 },
                        //    Stops = new object[,] { { 0, "rgb(116, 116, 116)" }, { 1, Color.Gold } }
                        //}),
                        LineWidth = 1,
                        Marker = new PlotOptionsAreaMarker
                        {
                            Enabled = false,
                            States = new PlotOptionsAreaMarkerStates
                            {
                                Hover = new PlotOptionsAreaMarkerStatesHover
                                {
                                    Enabled = true,
                                    Radius = 5
                                }
                            }
                        },
                        Shadow = false,
                        States = new PlotOptionsAreaStates { Hover = new PlotOptionsAreaStatesHover { LineWidth = 1 } },
                        PointInterval = PointInterval,
                        PointStart = new PointStart(PointStartDate)
                    }
                })
                .SetSeries(Series);
            return chart;
        }
