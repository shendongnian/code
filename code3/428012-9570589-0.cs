    public class SemiCircle : Shape
    {
        /// <summary>
        /// Gets or set the alignment of the semicircle. I.e. where should the flat part point.
        /// </summary>
        public SemiCircleAlignment Alignment
        {
            get { return (SemiCircleAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for alignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlignmentProperty =
            DependencyProperty.Register("Alignment", typeof(SemiCircleAlignment), typeof(SemiCircle), 
            new FrameworkPropertyMetadata(SemiCircleAlignment.Top,FrameworkPropertyMetadataOptions.AffectsRender));
        protected override System.Windows.Media.Geometry DefiningGeometry
        {
            get 
            {
                StreamGeometry geometry = new StreamGeometry();
                using (StreamGeometryContext context = geometry.Open())
                {
                    DrawSemiCircle(context);
                }
                geometry.Freeze();
                return geometry;
            }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            if (constraint.Height == double.PositiveInfinity || constraint.Width == double.PositiveInfinity)
            {
                if (double.IsNaN(Width) || double.IsNaN(Height))
                {
                    return new Size(0, 0);
                }
                return new Size(Width, Height);
            }
            return constraint;
        }
        private void DrawSemiCircle(StreamGeometryContext context)
        {
            double tOff = StrokeThickness / 2.0;                // an offset to account for stroke thickness
            Point startPt = new Point(tOff, tOff);                                   // upper left corner
            if (Alignment == SemiCircleAlignment.Bottom || Alignment == SemiCircleAlignment.Right)
            {
                startPt = new Point(ActualWidth - tOff, ActualHeight - tOff);        // or lower right corner
            }
            Point endPt = new Point(ActualWidth - tOff,tOff);                         // upper right corner
            if (Alignment == SemiCircleAlignment.Left || Alignment == SemiCircleAlignment.Bottom)
            {
                endPt = new Point(tOff, ActualHeight - tOff);                         // or lower left corner
            }
            Size s = new Size(Math.Max(0.0,(ActualWidth / 2) - tOff), 
                Math.Max(0,ActualHeight - StrokeThickness));    // half width is radius
            SweepDirection sweep = SweepDirection.Counterclockwise;    
            if (Alignment == SemiCircleAlignment.Left || Alignment == SemiCircleAlignment.Right)
            {
                s = new Size(Math.Max(0,ActualWidth - StrokeThickness),
                    Math.Max(0.0,(ActualHeight / 2) - tOff));     // or half height is radius
                sweep = SweepDirection.Clockwise;
            }
            
            context.BeginFigure(startPt, true, true);
            context.ArcTo(endPt, s, 0, false, sweep, true, false);
        }
    }
    public enum SemiCircleAlignment { Left, Top, Right, Bottom };
