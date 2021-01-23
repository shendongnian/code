    public class MyDrawingVisual : DrawingVisual
    {
        public MyDrawingVisual()
        {
            VisualEdgeMode = EdgeMode.Aliased;
        }
    }
    public class DrawingComponent : FrameworkElement
    {
        private DrawingVisual visual = new MyDrawingVisual();
        public DrawingComponent()
        {
            AddVisualChild(visual);
            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawLine(new Pen(Brushes.Black, 1d), new Point(100, 100), new Point(100, 200));
                dc.DrawLine(new Pen(Brushes.Black, 1d), new Point(105.5, 100), new Point(105.5, 200));
                dc.DrawLine(new Pen(Brushes.Black, 1d), new Point(112, 100), new Point(112, 200));
            }
        }
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return visual;
        }
    }
