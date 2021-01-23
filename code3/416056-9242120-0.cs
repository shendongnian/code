    public class DrawingShape
    {
        public string Name { get; set; }
        public DrawingShapeType Type { get; set; }
        // other shared properties
        public virtual void Draw(Graphics g)
        {
        }
    }
    
    public class DrawingRectangle : DrawingShape
    {
        public DrawingRectangle()
        {
            Name = "Rectangle";
            Type = DrawingShapeType.Rectangle;
        }
        public override void Draw(Graphics g)
        {
            // draw this shape
        }
    }
    
    public enum DrawingShapeType
    {
        Rectangle,
        Ellipse,
        Line,
    }
