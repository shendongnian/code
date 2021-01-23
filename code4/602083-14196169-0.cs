            Dictionary<string, int> tags = new Dictionary<string,int>() { 
                { "test", 10 },
                { "my", 3 },
                { "code", 8 }
            };
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (string tagname in tags.Keys)
            {
                chart1.Series[0].Points.AddXY(tagname, tags[tagname]);
                //chart1.Series[0].IsValueShownAsLabel = true;
            }
