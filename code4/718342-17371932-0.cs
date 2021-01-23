    public class Line : Control
    {
        public Point start { get; set; }
        public Point end { get; set; }
        public Pen pen = new Pen(Color.Red);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, start, end);
            base.OnPaint(e);
        }
        
        public float DistanceToLine(Point x)
        {
            // do your distance calculation here based on the link provided.
        }
    }
