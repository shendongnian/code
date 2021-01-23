            chart1.ChartAreas.Add(new ChartArea());
            chart1.Series[0].IsValueShownAsLabel = true;
            int[] dataset = { 10, 40, 100, 600, 300 };
            var series1 = chart1.Series[0];
            foreach (var i in dataset)
            {               
                series1.ChartType = SeriesChartType.StackedBar;
                var index1 = series1.Points.AddY(i);
            }
            int j = 0;
            foreach (var point in series1.Points)
            {
                if (dataset[j] > 20)
                {
                    point.LabelForeColor = Color.Black;
                }
                else
                {
                    point.LabelForeColor = Color.Transparent;
                }
                j++;
            }
