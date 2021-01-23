    class ArcII:FrameworkElement
    {
        /// <summary>
        /// Center point of Arc.
        /// </summary>
        [Category("Arc")]
        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Center.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point), typeof(ArcII), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsRender));
        
        /// <summary>
        /// Forces the Arc to the center of the Parent container.
        /// </summary>
        [Category("Arc")]
        public bool OverrideCenter
        {
            get { return (bool)GetValue(OverrideCenterProperty); }
            set { SetValue(OverrideCenterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for OverrideCenter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverrideCenterProperty =
            DependencyProperty.Register("OverrideCenter", typeof(bool), typeof(ArcII), new FrameworkPropertyMetadata((bool)false, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// Start angle of arc, using standard coordinates. (Zero is right, CCW positive direction)
        /// </summary>
        [Category("Arc")]
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for StartAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(ArcII), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// Length of Arc in degrees.
        /// </summary>
        [Category("Arc")]
        public double SweepAngle
        {
            get { return (double)GetValue(SweepAngleProperty); }
            set { SetValue(SweepAngleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SweepAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SweepAngleProperty =
            DependencyProperty.Register("SweepAngle", typeof(double), typeof(ArcII), new FrameworkPropertyMetadata((double)180, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// Size of Arc.
        /// </summary>
        [Category("Arc")]
        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(ArcII), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));
        [Category("Arc")]
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(ArcII), new FrameworkPropertyMetadata((Brush)Brushes.Black,FrameworkPropertyMetadataOptions.AffectsRender));
        [Category("Arc")]
        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(ArcII), new FrameworkPropertyMetadata((double)1,FrameworkPropertyMetadataOptions.AffectsRender));
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            Draw(dc);
        }
        private void Draw(DrawingContext dc)
        {
            Point center = new Point();
            if (OverrideCenter)
            {
                Rect rect = new Rect(RenderSize);
                center = Polar.CenterPointFromRect(rect);
            }
            else
            {
                center = Center;
            }
            Point startPoint = Polar.PolarToCartesian(StartAngle, Radius, center);
            Point endPoint = Polar.PolarToCartesian(StartAngle + SweepAngle, Radius, center);
            Size size = new Size(Radius, Radius);
            bool isLarge = (StartAngle + SweepAngle) - StartAngle > 180;
            List<PathSegment> segments = new List<PathSegment>(1);
            segments.Add(new ArcSegment(endPoint, new Size(Radius, Radius), 0.0, isLarge, SweepDirection.Clockwise, true));
            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(startPoint, segments, true);
            pf.IsClosed = false;
            figures.Add(pf);
            Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);
            dc.DrawGeometry(null, new Pen(Stroke,StrokeThickness), g);
        }
    }
