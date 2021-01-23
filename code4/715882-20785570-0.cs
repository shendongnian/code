<Code>System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartarea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartarea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(chartarea1);
            chart1.ChartAreas.Add(chartarea2);</Code>
Then you create some series; each series will be associated with a chart area. if you create 5 series and associate series1, series2 and series3 to chartarea1 then those series must be same or compatible chart type. otherwise Runtime error will occur. Multiple series In same Chart Area may have different x axis component in some cases. for example in the following code: series1 has 3 data points and series2 has 5, in this case chartarea will show first three x values from series1 and next two x values from series2.
<Code>chart1.Series.Clear();
chart1.Series.Add("Series1");
chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[0].ChartArea = chart1.ChartAreas[0].Name;
            chart1.Series[0].Points.AddXY("Point1", 20);
            chart1.Series[0].Points.AddXY("Point2", 50);
            chart1.Series[0].Points.AddXY("Point3",30);
            
            
            chart1.Series.Add("Series2");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].ChartArea = chart1.ChartAreas[0].Name;
            chart1.Series[1].Points.AddXY("newname1", 10);
            chart1.Series[1].Points.AddXY("newname2", 20);
            chart1.Series[1].Points.AddXY("newname3", 30);
            chart1.Series[1].Points.AddXY("newname4", 40);
            chart1.Series[1].Points.AddXY("newname5", 50);
            this.tabPage3.Controls.Add(chart1);
            chart1.Dock = System.Windows.Forms.DockStyle.Fill;
</Code>
