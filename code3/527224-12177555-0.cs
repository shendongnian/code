        private List< int > mBorderWidths	= null;
		private void LineChartPrePaint( object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e )
		{
			if ( e.ChartElement.GetType() == typeof( System.Windows.Forms.DataVisualization.Charting.ChartArea ) )
			{
				System.Windows.Forms.DataVisualization.Charting.Chart			c	= (System.Windows.Forms.DataVisualization.Charting.Chart)e.Chart;
				System.Windows.Forms.DataVisualization.Charting.ChartArea		ca	= (System.Windows.Forms.DataVisualization.Charting.ChartArea)e.ChartElement;
				mBorderWidths	= new List<int>();
				foreach( System.Windows.Forms.DataVisualization.Charting.Series s in c.Series )
				{
					mBorderWidths.Add( s.BorderWidth );
					s.BorderWidth	= 0;
					s.ShadowOffset	= 0;
				}
				RectangleF rectF	= ca.Position.ToRectangleF();
				rectF				= e.ChartGraphics.GetAbsoluteRectangle( rectF );
				e.ChartGraphics.Graphics.FillRectangle( new SolidBrush( ca.BackColor ), rectF );
			}
			if ( e.ChartElement.GetType() == typeof( System.Windows.Forms.DataVisualization.Charting.Chart ) )
			{
				RectangleF rectF	= e.Position.ToRectangleF();
				rectF				= e.ChartGraphics.GetAbsoluteRectangle( rectF );
				e.ChartGraphics.Graphics.FillRectangle( new SolidBrush( e.Chart.BackColor ), rectF );
			}
		}
		System.Drawing.Drawing2D.DashStyle ChartToDrawingDashStyle( System.Windows.Forms.DataVisualization.Charting.ChartDashStyle cds )
		{
			switch( cds )
			{
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet:
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid:
					return System.Drawing.Drawing2D.DashStyle.Solid;
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash:
					return System.Drawing.Drawing2D.DashStyle.Dash;
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot:
					return System.Drawing.Drawing2D.DashStyle.DashDot;
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot:
					return System.Drawing.Drawing2D.DashStyle.DashDotDot;
				case System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot:
					return System.Drawing.Drawing2D.DashStyle.Dot;
			}
			return System.Drawing.Drawing2D.DashStyle.Solid;
		}
		private void LineChartPostPaint( object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e )
		{
			if ( e.ChartElement.GetType() == typeof( System.Windows.Forms.DataVisualization.Charting.ChartArea ) )
			{
				System.Windows.Forms.DataVisualization.Charting.Chart		c	= (System.Windows.Forms.DataVisualization.Charting.Chart)e.Chart;
				System.Windows.Forms.DataVisualization.Charting.ChartArea	ca	= (System.Windows.Forms.DataVisualization.Charting.ChartArea)e.ChartElement;
				
				RectangleF clipRect	= e.ChartGraphics.GetAbsoluteRectangle( e.Position.ToRectangleF() );
				RectangleF oldClip	= e.ChartGraphics.Graphics.ClipBounds;
				e.ChartGraphics.Graphics.SetClip( clipRect );
						
				int seriesIdx	= 0;
				foreach( System.Windows.Forms.DataVisualization.Charting.Series s in c.Series )
				{
					PointF  ptFLast			= new PointF( 0.0f, 0.0f );
					List< PointF > points	= new List<PointF>();
					foreach( System.Windows.Forms.DataVisualization.Charting.DataPoint dp in s.Points )
					{
						double dx	= (double)dp.XValue;
						double dy	= (double)dp.YValues[0];
						// Log the value if its axis is logarithmic.
						if ( ca.AxisX.IsLogarithmic )
						{
							dx	= Math.Log10( dx );
						}
						if ( ca.AxisY.IsLogarithmic )
						{
							dy	= Math.Log10( dy );
						}
						dx	= e.ChartGraphics.GetPositionFromAxis( ca.Name, System.Windows.Forms.DataVisualization.Charting.AxisName.X, dx );
						dy	= e.ChartGraphics.GetPositionFromAxis( ca.Name, System.Windows.Forms.DataVisualization.Charting.AxisName.Y, dy );
						PointF	ptFThis			= e.ChartGraphics.GetAbsolutePoint( new PointF( (float)dx, (float)dy ) );
						points.Add( ptFThis );
					}
					
					if ( points.Count > 0 )
					{
						Pen pen = new Pen( Color.FromArgb( 255, s.Color ) );
						pen.Width		= mBorderWidths[seriesIdx];
						pen.DashStyle	= ChartToDrawingDashStyle( s.BorderDashStyle );
						//pen.DashStyle	= System.Drawing.Drawing2D.DashStyle.Custom;
						//pen.DashPattern	= new float[]{ 4.0f, 4.0f, 1.0f, 3.0f, 2.0f, 3.0f };
						pen.DashCap		= System.Drawing.Drawing2D.DashCap.Round;
						e.ChartGraphics.Graphics.SmoothingMode	= System.Drawing.Drawing2D.SmoothingMode.HighQuality;
						e.ChartGraphics.Graphics.DrawLines( pen, points.ToArray() );
						
					}
					s.BorderWidth	= mBorderWidths[seriesIdx];
				}
				e.ChartGraphics.Graphics.SetClip( oldClip );
			}
		}
