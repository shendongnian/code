            var chart = new TChart();
            var series = new Pie();
            chart.Series.Add(series);
            series.FillSampleValues(6);
            series.BevelPercent = 20;
            series.EdgeStyle = EdgeStyles.Curved;
            this.Controls.Add(chart);
