    public abstract class DrawingObject
    {
        public abstract void Draw(Graphics g);
    }
    public class Line : DrawingObject
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public float Thickness { get; set; }
        public Color Color { get; set; }
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color, Thickness), Start, End);
        }
    }
    // Other classes derived from `DrawingObject`
