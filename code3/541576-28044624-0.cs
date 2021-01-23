            // 
            // chart
            //
            System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart(); 
            chart.Size = new System.Drawing.Size(640, 320);
            chart.ChartAreas.Add("ChartArea1");
            chart.Legends.Add("legend1");
            // Plot {sin(x), 0, 2pi} 
            chart.Series.Add("sin");
            chart.Series["sin"].LegendText = "Sin(x)";
            chart.Series["sin"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (double x = 0; x < 2 * Math.PI; x += 0.01)
            {
                chart.Series["sin"].Points.AddXY(x, Math.Sin(x));
            }
            // Save sin_0_2pi.png image file
            chart.SaveImage("sin_0_2pi.png", System.Drawing.Imaging.ImageFormat.Png);
