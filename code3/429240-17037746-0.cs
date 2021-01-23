    public class DisplayRange
    {
        public double Start { get; set; }
        public double End { get; set; }
        public DisplayRange(double start, double end)
        {
            Start = start;
            End = end;
        }
    }
    public class ViewportAxesRangeRestriction : IViewportRestriction
    {
        public DisplayRange XRange = null;
        public DisplayRange YRange = null;
        public Rect Apply(Rect oldVisible, Rect newVisible, Viewport2D viewport)
        {
            if (XRange != null)
            {
                newVisible.X = XRange.Start;
                newVisible.Width = XRange.End - XRange.Start;
            }
            
            if (YRange != null)
            {
                newVisible.Y = YRange.Start;
                newVisible.Height = YRange.End - YRange.Start;
            }
            return newVisible;
        }
       
        public event EventHandler Changed;
    }
