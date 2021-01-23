    // this would most likely be done through the designer
    chartArea1.AxisX.ScaleView.Zoomable = false;
    chartArea1.CursorX.IsUserEnabled = true;
    chartArea1.CursorX.IsUserSelectionEnabled = true;
    this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
    ...
    
    private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            chart1.ChartAreas[0].AxisX.StripLines.Clear();
            StripLine stripLine1 = new StripLine();
            stripLine1.Interval = 0;
            stripLine1.StripWidth = chart1.ChartAreas[0].CursorX.SelectionStart - chart1.ChartAreas[0].AxisX.Minimum;
            stripLine1.IntervalOffset = chart1.ChartAreas[0].AxisX.Minimum;
            // pick you color etc ... before adding the stripline to the axis
            stripLine1.BackColor = Color.Blue;
            chart1.ChartAreas[0].AxisX.StripLines.Add(stripLine1);
            StripLine stripLine2 = new StripLine();
            stripLine2.Interval = 0;
            stripLine2.StripWidth = chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].CursorX.SelectionEnd;
            stripLine2.IntervalOffset = chart1.ChartAreas[0].CursorX.SelectionEnd;
            // pick you color etc ... before adding the stripline to the axis
            stripLine2.BackColor = Color.Blue;
            chart1.ChartAreas[0].AxisX.StripLines.Add(stripLine2);
        }
