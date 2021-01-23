    protected override void OnDraw(DrawingContext drawingContext,
                                   StylusPointCollection stylusPoints,
                                   Geometry geometry, Brush fillBrush)
            {
                if (!_isManipulating)
                {
                    _isManipulating = true;
                    StylusDevice currentStylus = Stylus.CurrentStylusDevice;
                    this.Reset(currentStylus, stylusPoints);
                }
                _isManipulating = false;
    
                var pen = new Pen(brush, 2);
                drawingContext.DrawLine(pen, startPoint,stylusPoints.First().ToPoint());
           }
    protected override void OnStylusDown(RawStylusInput rawStylusInput)
            {
                StylusPointCollection y = rawStylusInput.GetStylusPoints();
                startPoint = (Point)y.First();
    
                // Allocate memory to store the previous point to draw from.
                prevPoint = new Point(double.NegativeInfinity, double.NegativeInfinity);
                base.OnStylusDown(rawStylusInput);
            }
