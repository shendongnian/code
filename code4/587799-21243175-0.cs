	// Call this method from the Form_Load method, passing your ZedGraphControl
	public void CreateChart( ZedGraphControl zgc )
	{
		GraphPane myPane = zgc.GraphPane;
		
		// Set the titles and axis labels
		myPane.Title.Text = "Demo of Labeled Points";
		myPane.XAxis.Title.Text = "Time, Seconds";
		myPane.YAxis.Title.Text = "Pressure, Psia";
		
		// Build a PointPairList with points based on Sine wave
		PointPairList list = new PointPairList();
		const int count = 15;
		for ( int i = 0; i < count; i++ )
		{
			double x = i + 1;
		
			double y = 21.1 * ( 1.0 + Math.Sin( (double)i * 0.15 ) );
		
			list.Add( x, y );
		}
		
		// Hide the legend
		myPane.Legend.IsVisible = false;
		
		// Add a curve
		LineItem curve = myPane.AddCurve( "label", list, Color.Red, SymbolType.Circle );
		curve.Line.Width = 2.0F;
		curve.Line.IsAntiAlias = true;
		curve.Symbol.Fill = new Fill( Color.White );
		curve.Symbol.Size = 7;
		
		// Fill the axis background with a gradient
		myPane.Chart.Fill = new Fill( Color.White, Color.FromArgb( 255, Color.ForestGreen ), 45.0F );
		
		// Offset Y space between point and label
		// NOTE:  This offset is in Y scale units, so it depends on your actual data
		const double offset = 1.0;
		
		// Loop to add text labels to the points
		for ( int i = 0; i < count; i++ )
		{
			// Get the pointpair
			PointPair pt = curve.Points[i];
		
			// Create a text label from the Y data value
			TextObj text = new TextObj( pt.Y.ToString( "f2" ), pt.X, pt.Y + offset,
				CoordType.AxisXYScale, AlignH.Left, AlignV.Center );
			text.ZOrder = ZOrder.A_InFront;
			// Hide the border and the fill
			text.FontSpec.Border.IsVisible = false;
			text.FontSpec.Fill.IsVisible = false;
			//text.FontSpec.Fill = new Fill( Color.FromArgb( 100, Color.White ) );
			// Rotate the text to 90 degrees
			text.FontSpec.Angle = 90;
		
			myPane.GraphObjList.Add( text );
		}
		
		// Leave some extra space on top for the labels to fit within the chart rect
		myPane.YAxis.Scale.MaxGrace = 0.2;
		
		// Calculate the Axis Scale Ranges
		zgc.AxisChange();
	}
