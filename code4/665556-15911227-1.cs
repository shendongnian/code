	private void button1_Click(object sender, EventArgs e)
	{
		var s = new Series();
		s.ChartType = SeriesChartType.Line;
		var d = new DateTime(2013, 04, 01);
		s.Points.AddXY(d, 3);
		s.Points.AddXY(d.AddMonths(-1), 2);
		s.Points.AddXY(d.AddMonths(-2), 1);
		s.Points.AddXY(d.AddMonths(-3), 4);
		chart1.Series.Clear();
		chart1.Series.Add(s);
		chart1.Series[0].XValueType = ChartValueType.DateTime;
		chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
		chart1.ChartAreas[0].AxisX.Interval = 1;
		chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
		chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
		chart1.Series[0].XValueType = ChartValueType.DateTime;
		DateTime minDate = new DateTime(2013, 01, 01).AddSeconds(-1);
		DateTime maxDate = new DateTime(2013, 05, 01); // or DateTime.Now;
		chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
		chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();
	}
