    internal class Rectangle
    {
        public PointF Position { get; set; }
        public Color Color { get; set; }
        public SizeF Size { get; set; }
        
        public float Rotation { get; set; }
        public RectangleF GetRelativeBoundingRectangle()
        {            
            return new RectangleF(
                new PointF(-this.Size.Width / 2.0f, -this.Size.Height / 2.0f),
                this.Size);
        }
    }
