    public class CountdownRect : Shape
    {
        static CountdownRect()
        {
            WidthProperty.OverrideMetadata(typeof(CountdownRect),
                new FrameworkPropertyMetadata((o, e) => ((CountdownRect)o).GeometryChanged()));
            HeightProperty.OverrideMetadata(typeof(CountdownRect),
                new FrameworkPropertyMetadata((o, e) => ((CountdownRect)o).GeometryChanged()));
            StrokeLineJoinProperty.OverrideMetadata(typeof(CountdownRect),
                new FrameworkPropertyMetadata(PenLineJoin.Round));
        }
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CountdownRect),
                new FrameworkPropertyMetadata((o, e) => ((CountdownRect)o).GeometryChanged()));
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        private readonly StreamGeometry geometry = new StreamGeometry();
        protected override Geometry DefiningGeometry
        {
            get { return geometry; }
        }
        private void GeometryChanged()
        {
            if (!double.IsNaN(Width) && !double.IsNaN(Height))
            {
                var angle = ((Angle % 360d) + 360d) % 360d;
                var margin = StrokeThickness / 2d;
                var p0 = new Point(margin, margin);
                var p1 = new Point(Width - margin, margin);
                var p2 = new Point(Width - margin, Height - margin);
                var p3 = new Point(margin, Height - margin);
                using (var context = geometry.Open())
                {
                    if (angle == 0d)
                    {
                        context.BeginFigure(p0, true, true);
                        context.LineTo(p1, true, false);
                        context.LineTo(p2, true, false);
                        context.LineTo(p3, true, false);
                    }
                    else
                    {
                        var x = p2.X / 2d;
                        var y = p2.Y / 2d;
                        var a = Math.Atan2(x, y) / Math.PI * 180d;
                        var t = Math.Tan(angle * Math.PI / 180d);
                        context.BeginFigure(new Point(x, y), true, true);
                        if (angle < a)
                        {
                            context.LineTo(new Point(x + y * t, p0.Y), true, false);
                            context.LineTo(p1, true, false);
                            context.LineTo(p2, true, false);
                            context.LineTo(p3, true, false);
                            context.LineTo(p0, true, false);
                        }
                        else if (angle < 180d - a)
                        {
                            context.LineTo(new Point(p2.X, y - x / t), true, false);
                            context.LineTo(p2, true, false);
                            context.LineTo(p3, true, false);
                            context.LineTo(p0, true, false);
                        }
                        else if (angle < 180d + a)
                        {
                            context.LineTo(new Point(x - y * t, p2.Y), true, false);
                            context.LineTo(p3, true, false);
                            context.LineTo(p0, true, false);
                        }
                        else if (angle < 360d - a)
                        {
                            context.LineTo(new Point(p0.X, y + x / t), true, false);
                            context.LineTo(p0, true, false);
                        }
                        else
                        {
                            context.LineTo(new Point(x + y * t, p0.Y), true, false);
                        }
                        context.LineTo(new Point(x, p0.Y), true, false);
                    }
                }
            }
        }
    }
