    DataPoint _prevPoint;
    void chart1_MouseMove(object sender, MouseEventArgs e)
    {
		// this if statement clears the values from the previously activated point.
        if (_prevPoint) {
            _prevPoint.MarkerStyle = MarkerStyle.None;
            _prevPoint.IsValueShownAsLable = false;
            }
        var result = chart1.HitTest(pos.X, pos.Y, ChartElementType.DataPoint);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
					prop.IsValueShownAsLabel = true;
					prop.MarkerStyle = MarkerStyle.Star4;
				}
            }
    }
