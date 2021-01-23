        public System.Drawing.Color GetBarColour(int value)
        {
            if (value < 5) return System.Drawing.Color.Red;
            if (value > 7) return System.Drawing.Color.Green;
            return System.Drawing.Color.Orange;
        }
        public ActionResult OfficeStatistic()
        {
            {
                var dataItems = new[] {1, 8, 9, 6};
                Data data = new Data(
                    dataItems.Select(y => new Point {Color = GetBarColour(y), Y = y}).ToArray()
                );
                Highcharts chart1 = new Highcharts("chart1")
                    .SetXAxis(new XAxis { Categories = new[] { "Ödmjukhet", "Engagemang", "Kompetens", "Lönsamhet" } })
                    .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Betygskalan" } })
                    .SetSeries(new Series { Data = data, Name = "Snittbetyg" })
                    .SetTitle(new Title { Text = "Örebro Statistik" })
                    .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                    .SetLegend(new Legend { Enabled = false });
