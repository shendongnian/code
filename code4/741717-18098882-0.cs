        private void Form1_Load(object sender, EventArgs e)
        {
            Series series1 = new Series("Series 1", ViewType.Point);
            series1.Points.Add(new SeriesPoint(1, 50));
            series1.Points.Add(new SeriesPoint(2, 150));
            series1.Points.Add(new SeriesPoint(4, 20));
            series1.Points.Add(new SeriesPoint(7, 210));
            series1.Points.Add(new SeriesPoint(12, 70));
            chartControl1.Series.Add(series1);
            XYDiagram diagram = chartControl1.Diagram as XYDiagram;
            foreach (SeriesPoint item in series1.Points)
            {
                DrawConstantLines(diagram, int.Parse(item.Argument), diagram.AxisX);
                DrawConstantLines(diagram, (int)item.Values[0], diagram.AxisY);
            }
        }
        private void DrawConstantLines(XYDiagram diagram, int value, Axis axis)
        {
            ConstantLine constantLine1 = new ConstantLine();
            axis.ConstantLines.Add(constantLine1);
            constantLine1.AxisValue = value;
        }
