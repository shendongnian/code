    private void cmdHidden_Click(object sender, EventArgs e) {
        System.Windows.Forms.DataVisualization.Charting.Title chtTitle =
            new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Drawing.Font chtFont = new System.Drawing.Font("Arial", 42);
        string[] seriesArray = { "A", "B", "C" };
        int[] pointsArray = { 1, 7, 4 };
    
        chart1.Visible = false;
        chart1.Width = 2100;
        chart1.Height = 1500;
        chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
    
        chtTitle.Font = chtFont;
        chtTitle.Text = "Demographics Comparison";
        chart1.Titles.Add(chtTitle);
    
        chart1.Series.Clear();
        // populate chart    
        for (int i = 0; i < seriesArray.Length; i++) {
            Series series = chart1.Series.Add(seriesArray[i]);
            series.Label = seriesArray[i].ToString();
            series.Font = new System.Drawing.Font("Arial", 24);
            series.ShadowOffset = 5;
            series.Points.Add(pointsArray[i]);
        }
        // save from the chart object itself
        chart1.SaveImage(@"C:\Temp\HiddenChart.png", ChartImageFormat.Png);
        // save to a bitmap
        Bitmap bmp = new Bitmap(2100, 1500);
        chart1.DrawToBitmap(bmp, new Rectangle(0, 0, 2100, 1500));
        bmp.Save(@"C:\Temp\HiddenChart2.png");
    }
